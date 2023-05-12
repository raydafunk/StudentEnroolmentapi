using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentEnrollment.data;
using StudentEnrollment.data.Contracts.Interfaces.CouresInterface;
using StudentEnrollment.data.Contracts.Interfaces.StudentEnrollment;
using StudentEnrollment.data.Reposistories.CourseRepo;
using StudentEnrollment.data.Reposistories.EnrollmentRepo;
using StudentEnrollment.data.Reposistories.StudentRepo;
using StudentEnroolment.API.Configuration;
using StudentEnroolment.API.EndPoints;
using StudentEnroolment.API.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("SchoolDbConnection");

builder.Services.AddDbContext<StudentEnorllmentDbContext>(optionsAction: options =>
{
    options.UseSqlServer(conn);
});

builder.Services.AddIdentityCore<SchoolUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<StudentEnorllmentDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>{
        options.TokenValidationParameters = new TokenValidationParameters
        {
           ValidateIssuer = true,
           ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
           ValidateAudience= true,
           ValidAudience = builder.Configuration["JwtSettings.Audience"],
           ValidateLifetime =true,
           ClockSkew = TimeSpan.Zero,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
        };
    });

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddAuthorization(options => {
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser()
    .Build();
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEnrollmentRepository, EnrollementRespistory>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAuthManager, AuthManager>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization(); 

app.MapStudentEndpoints();

app.MapEnrollmentEndpoints();

app.MapCourseEndpoints();

app.MapAuthenacationEndpoints();

app.Run();
