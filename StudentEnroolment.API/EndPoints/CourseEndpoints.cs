using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.data;
using StudentEnrollment.data.Models;
using StudentEnroolment.API.Dtos.CourseDto;

namespace StudentEnroolment.API.EndPoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        group.MapGet("/", async (StudentEnorllmentDbContext db) =>
        {
            var data = new List<CourseDto>();
            var courses = await db.Courses.ToListAsync();
            foreach (var course in courses)
            {
                data.Add(new CourseDto
                {
                    Title = course.Title,
                    Credits = course.Credits,
                    Id = course.Id,
                });
            }
            return data;
        })
        .WithName("GetAllCourses")
        .WithOpenApi()
        .Produces<List<CourseDto>>(StatusCodes.Status100Continue);

        group.MapGet("/{id}", async Task<Results<Ok<Course>, NotFound>> (int id, StudentEnorllmentDbContext db) =>
        {
            return await db.Courses.FindAsync(id)
                is Course model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCourseById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, CourseDto course, StudentEnorllmentDbContext db) =>
        {
            var foundModel = await db.Courses.FindAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }

            db.Update(course);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateCourse")
        .WithOpenApi();

        group.MapPost("/", async (CreatueCourseDto coursedto, StudentEnorllmentDbContext db) =>
        {
            var course = new Course()
            {
                Title = coursedto.Title,
                Credits = coursedto.Credits,
            };
            db.Courses.Add(course);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Course/{course.Id}", course);
        })
        .WithName("CreateCourse")
        .WithOpenApi();

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
        .WithOpenApi();
    }
}
