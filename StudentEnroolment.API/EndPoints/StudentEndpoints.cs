using Microsoft.EntityFrameworkCore;
using StudentEnrollment.data;
using StudentEnrollment.data.Models;
using AutoMapper;
using StudentEnroolment.API.Dtos.Student;

namespace StudentEnroolment.API.EndPoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        group.MapGet("/", async (StudentEnorllmentDbContext db, IMapper mapper) =>
        {
           
            var students = await db.Students.ToListAsync();
            return mapper.Map<List<StudentDto>>(students);
        })
        .WithName("GetAllStudents")
        .WithOpenApi()
        .Produces<List<StudentDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int Id, StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            return await db.Students.FindAsync(Id)
                is Student model
                    ? Results.Ok(mapper.Map<StudentDto>(model))
                    : Results.NotFound();
        })
        .WithName("GetStudentById")
        .WithOpenApi()
        .Produces<StudentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, Student student, StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            var foundModel = await db.Students.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(student);
            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateStudent")
        .WithOpenApi()
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (StudentDto studentDto, StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            var student = mapper.Map<Student>(studentDto);
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return Results.Created($"/api/Student/{student.Id}", student);
        })
        .WithName("CreateStudent")
        .WithOpenApi()
        .Produces<StudentDto>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            if (await db.Students.FindAsync(id) is Student student)
            {
                db.Students.Remove(student);
                await db.SaveChangesAsync();
                return Results.Ok(student);
            }

            return Results.NotFound();
        })
        .WithName("DeleteStudent")
        .WithOpenApi()
        .Produces<StudentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
