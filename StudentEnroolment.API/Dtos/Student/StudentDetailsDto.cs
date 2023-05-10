using StudentEnroolment.API.Dtos.Course;
using StudentEnroolment.API.Dtos.Enrollment;

namespace StudentEnroolment.API.Dtos.Student
{
    public class StudentDetailsDto : CreateStudentDto
    {
        public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }
}
