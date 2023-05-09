using Microsoft.EntityFrameworkCore;
using StudentEnrollment.data.Contracts.Interfaces.StudentEnrollment;
using StudentEnrollment.data.Models;

namespace StudentEnrollment.data.Reposistories.StudentRepo
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentEnorllmentDbContext db) : base(db)
        {
        }

        public async Task<Student> GetStudentDetails(int studnetId)
        {
            var  student =  await _db.Students
                .Include(q => q.Enrollments).ThenInclude(q => q.Course)
                .FirstOrDefaultAsync(q => q.Id== studnetId);

            return student ?? throw new Exception("Cant find student Id");

        }
    }
}
