using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StudentEnrollment.data.Configruration;
using StudentEnrollment.data.Models;

namespace StudentEnrollment.data
{
    public class StudentEnorllmentDbContext : IdentityDbContext<SchoolUser>
    {
        public StudentEnorllmentDbContext(DbContextOptions<StudentEnorllmentDbContext> options) :base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new SchoolUserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());  
        }
        public DbSet<Course> Courses { get; set; } 
        public DbSet<Student> Students { get; set; } 
        public DbSet<Enrollment> Enrollments { get; set; }
    }
    public class StudentEnrollmentDbContextFactory : IDesignTimeDbContextFactory<StudentEnorllmentDbContext>
    {
        public StudentEnorllmentDbContext CreateDbContext(string[] args)
        {
            // Get enviorment
            //string enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

            // Bulid Config
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get the connection string 
            var opitonbluder = new DbContextOptionsBuilder<StudentEnorllmentDbContext>();
            var connectionstring = configuration.GetConnectionString("SchoolDbConnection");
            opitonbluder.UseSqlServer(connectionstring);
            return new StudentEnorllmentDbContext(opitonbluder.Options);
        }
    }
}
