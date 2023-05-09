using Microsoft.EntityFrameworkCore;
using StudentEnrollment.data.Models;
using AutoMapper;
using StudentEnroolment.API.Dtos.Enrollment;
using StudentEnrollment.data.Contracts.Interfaces.CouresInterface;

namespace StudentEnroolment.API.EndPoints;

public static class EnrollmentEndpoints
{
    public static void MapEnrollmentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Enrollment").WithTags(nameof(Enrollment));

        group.MapGet("/", async (IEnrollmentRepository repo, IMapper mapper) =>
        {
            var enrollments = await repo.GetAllAsync();
            return mapper.Map<List<EnrollmentDto>>(enrollments);
        })
        .WithName("GetAllEnrollments")
        .WithOpenApi()
        .Produces<List<EnrollmentDto>>(StatusCodes.Status100Continue);

        group.MapGet("/{id}", async (int Id, IEnrollmentRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(Id)
                is Enrollment model
                    ? Results.Ok(mapper.Map<EnrollmentDto>(model))
                    : Results.NotFound();
        })
        .WithName("GetEnrollmentById")
        .WithOpenApi()
        .Produces<EnrollmentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int Id, EnrollmentDto enrollmentDto, IEnrollmentRepository repo, IMapper mapper) =>
        {
            var foundModel = await repo.GetAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            // update the model 
            mapper.Map(enrollmentDto, foundModel);
            await repo.UpdateAsync(foundModel);

            return Results.NoContent();
        })
        .WithName("UpdateEnrollment")
        .WithOpenApi()
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateEnrollmenDto enrollmentDto, IEnrollmentRepository repo, IMapper mapper) =>
        {
            var enrollment = mapper.Map<Enrollment>(enrollmentDto);
            await repo.AddAsync(enrollment);
            return Results.Created($"/api/Enrollment/{enrollment.Id}", enrollment);
        })
        .WithName("CreateEnrollment")
        .WithOpenApi()
        .Produces<CreateEnrollmenDto>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int Id, IEnrollmentRepository repo, IMapper mapper) =>
        {
            await repo.DeleteAsync(Id);
            return Results.NoContent();
        })
        .WithName("DeleteEnrollment")
        .WithOpenApi()
        .Produces<EnrollmentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
