using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using StudentEnrollment.data;
using StudentEnrollment.data.Models;
using StudentEnroolment.API.Dtos.Course;
using AutoMapper;

namespace StudentEnroolment.API.EndPoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        group.MapGet("/", async (StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            var courses = await db.Courses.ToListAsync();
            return mapper.Map<List<CourseDto>>(courses);
        })
        .WithName("GetAllCourses")
        .WithOpenApi()
        .Produces<List<CourseDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int Id, StudentEnorllmentDbContext db, IMapper mappper) =>
        {
            return await db.Courses.FindAsync(Id)
                is Course model
                    ? Results.Ok(mappper.Map<CourseDto>(model))
                    : Results.NotFound();
        })
        .WithName("GetCourseById")
        .WithOpenApi()
        .Produces<CourseDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, CourseDto courseDto, StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            var foundModel = await db.Courses.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            // udpate the model 
            mapper.Map(courseDto, foundModel);
            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateCourse")
        .WithOpenApi()
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreatueCourseDto coursedto, StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            var course = mapper.Map<Course>(coursedto);
            db.Courses.Add(course);
            await db.SaveChangesAsync();
            return Results.Created($"/api/Course/{course.Id}", course);
        })
        .WithName("CreateCourse")
        .WithOpenApi()
        .Produces<Course>(StatusCodes.Status201Created);


        group.MapDelete("/{id}", async Task<Results<Ok<Course>, NotFound>> (int id, StudentEnorllmentDbContext db) =>
        {
            if (await db.Courses.FindAsync(id) is Course course)
            {
                db.Courses.Remove(course);
                await db.SaveChangesAsync();
                return TypedResults.Ok(course);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteCourse")
        .WithOpenApi()
        .Produces<Course>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
