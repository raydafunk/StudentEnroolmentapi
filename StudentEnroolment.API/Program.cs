using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.data;
using StudentEnrollment.data.Contracts.Interfaces.CouresInterface;
using StudentEnrollment.data.Contracts.Interfaces.StudentEnrollment;
using StudentEnrollment.data.Reposistories.CourseRepo;
using StudentEnrollment.data.Reposistories.EnrollmentRepo;
using StudentEnrollment.data.Reposistories.StudentRepo;
using StudentEnroolment.API.Configuration;
using StudentEnroolment.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("SchoolDbConnection");

builder.Services.AddDbContext<StudentEnorllmentDbContext>(optionsAction: options =>
{   
    options.UseSqlServer(conn);
});

builder.Services.AddIdentityCore<SchoolUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<StudentEnorllmentDbContext>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IEnrollmentRepository, EnrollementRespistory>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

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

app.MapStudentEndpoints();

app.MapEnrollmentEndpoints();

app.MapCourseEndpoints();

app.Run();
