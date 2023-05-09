using StudentEnrollment.data.Models;

namespace StudentEnrollment.data.Contracts.Interfaces.StudentEnrollment
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> GetStudentDetails(int studnetId);
    }
}
