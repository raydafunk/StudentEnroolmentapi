using Microsoft.EntityFrameworkCore;
using StudentEnrollment.data.Contracts.Interfaces.CouresInterface;
using StudentEnrollment.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.data.Reposistories.CourseRepo
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(StudentEnorllmentDbContext db) : base(db)
        {
        }

        public async Task<Course> GetStudentLists(int courseId)
        {
            var course = await _db.Courses
                .Include(q => q.Enrollments)
                 .ThenInclude(q => q.Student)
                 .FirstOrDefaultAsync(q=> q.Id == courseId); 
            
            return course!;
        }
    }
}
