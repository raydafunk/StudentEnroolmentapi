using StudentEnroolment.API.Dtos.Authentication;
using StudentEnroolment.API.Dtos.Error;
using StudentEnroolment.API.Services;

namespace StudentEnroolment.API.EndPoints;

public static class AuthencationEndpoints
{
    public static void MapAuthenacationEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/login", async (LoginDto loginDto, IAuthManager authManger) =>
        {
            var response = await authManger.Login(loginDto);
            if (response is null)
            {
                return Results.Unauthorized();
            }
            return Results.Ok();
        })
        .AllowAnonymous()
        .WithTags("Authentication")
        .WithName("login")
        .WithOpenApi()  
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status401Unauthorized);

        routes.MapPost("/api/register", async (RegisterDto registorDto, IAuthManager authManger) =>
        {
            var response = await authManger.Register(registorDto);
            if (!response.Any())
            {
                return Results.Ok();
            }
            var errors = new List<ErrorResponseDto>();
            foreach (var error in response)
            {
                errors.Add(new ErrorResponseDto
                {
                    Code= error.Code,
                    Description= error.Description,
                });
            }
            return Results.BadRequest(errors);
        })

       .AllowAnonymous()
       .WithTags("Authentication")
       .WithName("Register")
       .WithOpenApi()
       .Produces(StatusCodes.Status201Created)
       .Produces(StatusCodes.Status400BadRequest);
    }
}
