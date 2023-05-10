using StudentEnrollment.data.Contracts.Interfaces.CouresInterface;
using StudentEnrollment.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.data.Reposistories.EnrollmentRepo
{
    public class EnrollementRespistory : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollementRespistory(StudentEnorllmentDbContext db) : base(db)
        {
        }
    }
}
