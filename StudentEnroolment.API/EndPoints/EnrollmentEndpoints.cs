using Microsoft.EntityFrameworkCore;
using StudentEnrollment.data;
using StudentEnrollment.data.Models;
using AutoMapper;
using StudentEnroolment.API.Dtos.Enrollment;

namespace StudentEnroolment.API.EndPoints;

public static class EnrollmentEndpoints
{
    public static void MapEnrollmentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Enrollment").WithTags(nameof(Enrollment));

        group.MapGet("/", async (StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            var enrollments = await db.Enrollments.ToListAsync();
            return mapper.Map<List<EnrollmentDto>>(enrollments);
        })
        .WithName("GetAllEnrollments")
        .WithOpenApi()
        .Produces<List<EnrollmentDto>>(StatusCodes.Status100Continue);

        group.MapGet("/{id}", async (int Id, StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            return await db.Enrollments.FindAsync(Id)
                is Enrollment model
                    ? Results.Ok(mapper.Map<EnrollmentDto>(model))
                    : Results.NotFound();
        })
        .WithName("GetEnrollmentById")
        .WithOpenApi()
        .Produces<EnrollmentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, EnrollmentDto enrollmentDto, StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            var foundModel = await db.Enrollments.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            // update the model 
            mapper.Map(enrollmentDto, foundModel);
            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateEnrollment")
        .WithOpenApi()
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateEnrollmenDto enrollmentDto, StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            var enrollment = mapper.Map<Enrollment>(enrollmentDto);
            db.Enrollments.Add(enrollment);
            await db.SaveChangesAsync();
            return Results.Created($"/api/Enrollment/{enrollment.Id}", enrollment);
        })
        .WithName("CreateEnrollment")
        .WithOpenApi()
        .Produces<CreateEnrollmenDto>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, StudentEnorllmentDbContext db, IMapper mapper) =>
        {
            if (await db.Enrollments.FindAsync(id) is Enrollment enrollment)
            {
                db.Enrollments.Remove(enrollment);
                await db.SaveChangesAsync();
                return Results.Ok(enrollment);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteEnrollment")
        .WithOpenApi()
        .Produces<EnrollmentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
