using StudentEnroolment.API.Dtos.Course;
using StudentEnroolment.API.Dtos.Student;

namespace StudentEnroolment.API.Dtos.Enrollment
{
    public class EnrollmentDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public virtual CourseDto? Course { get; set; }
        public virtual StudentDto? Student { get; set; }
    }
}
