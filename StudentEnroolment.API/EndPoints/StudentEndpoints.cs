using StudentEnrollment.data.Models;
using AutoMapper;
using StudentEnroolment.API.Dtos.Student;
using StudentEnrollment.data.Contracts.Interfaces.StudentEnrollment;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using StudentEnroolment.API.Services;
using System.ComponentModel.DataAnnotations;
using StudentEnroolment.API.Filters;

namespace StudentEnroolment.API.EndPoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        group.MapGet("/", async (IStudentRepository repo, IMapper mapper) =>
        {

            var students = await repo.GetAllAsync();
            return mapper.Map<List<StudentDto>>(students);
        })

        .WithName("GetAllStudents")
        .WithOpenApi()
        .Produces<List<StudentDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int Id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(Id)
                is Student model
                    ? Results.Ok(mapper.Map<StudentDto>(model))
                    : Results.NotFound();
        })
        .WithName("GetStudentById")
        .WithOpenApi()
        .Produces<StudentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/GetDetails/{id}", async (int Id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.GetStudentDetails(Id)
            is Student model
                ? Results.Ok(mapper.Map<StudentDetailsDto>(model))
                : Results.NotFound();
        })
       .WithName("GetStudentDetailsById")
       .WithOpenApi()
       .Produces<StudentDetailsDto>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int Id, StudentDto studentDto, IStudentRepository repo, IMapper mapper,
            IValidator<StudentDto> validator, IFileUpload fileUpload) =>
           {
               var validationResult = await validator.ValidateAsync(studentDto);

               if (!validationResult.IsValid)
               {
                   return Results.BadRequest(validationResult.ToDictionary());
               }

               var foundModel = await repo.GetAsync(Id);

               if (foundModel is null)
               {
                   return Results.NotFound();
               }

               mapper.Map(studentDto, foundModel);

               if (studentDto.ProfilePicture != null)
               {
                   foundModel.Picture = fileUpload.UploadStudentFile(studentDto.ProfilePicture, studentDto.OrignalFilename);
               }
               await repo.UpdateAsync(foundModel);
               return Results.NoContent();
           })
        .WithName("UpdateStudent")
        .WithOpenApi()
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", [Authorize(Roles = "Adminstrator")] async (CreateStudentDto studentDto, IStudentRepository repo, IMapper mapper,
            IValidator<CreateStudentDto> validator, IFileUpload fileUpload) =>
        {
            var validationResult = await validator.ValidateAsync(studentDto);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }

            var student = mapper.Map<Student>(studentDto);
            student.Picture = fileUpload.UploadStudentFile(studentDto.ProfilePicture, studentDto.OrignalFilename);
            await repo.AddAsync(student);

            return Results.Created($"/api/Student/{student.Id}", student);
        })
        .AddEndpointFilter<ValidationFilter<CreateStudentDto>>()
        .AddEndpointFilter<LoggingFilters>()
        .WithName("CreateStudent")
        .WithOpenApi()
        .Produces<StudentDto>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", [Authorize(Roles = "Administrator")] async (int Id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.DeleteAsync(Id) ? Results.NoContent() : Results.NoContent();
        })
        .WithName("DeleteStudent")
        .WithOpenApi()
        .Produces<StudentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
