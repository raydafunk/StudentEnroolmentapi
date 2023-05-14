using StudentEnrollment.data.Models;
using StudentEnroolment.API.Dtos.Course;
using AutoMapper;
using StudentEnrollment.data.Contracts.Interfaces.CouresInterface;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace StudentEnroolment.API.EndPoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        group.MapGet("/", async (ICourseRepository repo, IMapper mapper) =>
        {
            var courses =  await repo.GetAllAsync();
            return mapper.Map<List<CourseDto>>(courses);
        })

        .AllowAnonymous()
        .WithName("GetAllCourses")
        .WithOpenApi()
        .Produces<List<CourseDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int Id, ICourseRepository repo, IMapper mappper) =>
        {
            return await repo.GetAsync(Id)
                is Course model
                    ? Results.Ok(mappper.Map<CourseDto>(model))
                    : Results.NotFound();
        })
        .WithName("GetCourseById")
        .WithOpenApi()
        .Produces<CourseDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/GetStudents/{id}", async (int Id, ICourseRepository repo, IMapper mappper) =>
        {
            return await repo.GetStudentLists(Id)
                is Course model
                    ? Results.Ok(mappper.Map<CourseDetailsDto>(model))
                    : Results.NotFound();
        })
        .WithName("GeCourseDetailsById")
        .WithOpenApi()
        .Produces<CourseDetailsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);


        group.MapPut("/{id}", async (int Id, CourseDto courseDto, ICourseRepository repo, IMapper mapper, IValidator<CourseDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(courseDto);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }

            var foundModel = await repo.GetAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            // udpate the model 
            mapper.Map(courseDto, foundModel);
            await repo.UpdateAsync(foundModel);

            return Results.NoContent();
        })
        .WithName("UpdateCourse")
        .WithOpenApi()
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateCourseDto courseDto, ICourseRepository repo, IMapper mapper, IValidator<CreateCourseDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(courseDto);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }
            var course = mapper.Map<Course>(courseDto);
            await repo.AddAsync(course);
            return Results.Created($"/api/Course/{course.Id}", course);
        })
        .WithName("CreateCourse")
        .WithOpenApi()
        .Produces<CreateCourseDto>(StatusCodes.Status201Created);


        group.MapDelete("/{id}", [Authorize(Roles = "Administrator")] async (int Id, ICourseRepository repo, IMapper mapper) =>
        {
            return await repo.DeleteAsync(Id) ? Results.NoContent() : Results.NoContent();
       
        })
        .WithName("DeleteCourse")
        .WithOpenApi()
        .Produces<CourseDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
