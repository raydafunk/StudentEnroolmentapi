using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.data.Configruration;
using StudentEnrollment.data.Models;

namespace StudentEnrollment.data
{
    public class StudentEnorllmentDbContext : IdentityDbContext
    {
        public StudentEnorllmentDbContext(DbContextOptions<StudentEnorllmentDbContext> options) :base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new UserRoleCourseConfiguration());
        }
        public DbSet<Course> Courses { get; set; } 
        public DbSet<Student> Students { get; set; } 
        public DbSet<Enrollment> Enrollments { get; set; }

        
        
        
    }
}
