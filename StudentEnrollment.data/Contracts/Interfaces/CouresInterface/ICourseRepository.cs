using StudentEnrollment.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.data.Contracts.Interfaces.CouresInterface
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course> GetStudentLists(int studnetId);
    }
}
