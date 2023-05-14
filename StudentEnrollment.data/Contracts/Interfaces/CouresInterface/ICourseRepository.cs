using StudentEnrollment.data.Models;

namespace StudentEnrollment.data.Contracts.Interfaces.CouresInterface
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course> GetStudentLists(int studnetId);
    }
}
