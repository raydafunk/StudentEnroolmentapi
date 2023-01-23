using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentEnrollment.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.data.Configruration
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                 new Course
                 {
                     Id = 1,
                     Title = "Minimal API development",
                     Credits = 3
                    
                 },
                 new Course
                 {
                     Id = 2,
                     Title = "Ultimate API development",
                     Credits = 4
                 }
                );
        }
    }
}
