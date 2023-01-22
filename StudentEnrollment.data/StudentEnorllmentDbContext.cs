using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.data
{
    public class StudentEnorllmentDbContext : IdentityDbContext
    {
        public StudentEnorllmentDbContext(DbContextOptions<StudentEnorllmentDbContext> options) :base(options)
        {
                
        }
        public DbSet<Course> Courses { get; set; } 
        public DbSet<Student> Students { get; set; } 
        public DbSet<Enrollment> Enrollments { get; set; }

        
        
        
    }
}
