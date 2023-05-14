using FluentValidation;
using StudentEnrollment.data.Contracts.Interfaces.CouresInterface;
using StudentEnrollment.data.Contracts.Interfaces.StudentEnrollment;
using StudentEnroolment.API.Dtos.Course;
using StudentEnroolment.API.Dtos.Student;

namespace StudentEnroolment.API.Dtos.Enrollment
{
    public class EnrollmentDto : CreateEnrollmentDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public virtual CourseDto? Course { get; set; }
        public virtual StudentDto? Student { get; set; }
    }
    public class EnrollmentDtoValidator : AbstractValidator<EnrollmentDto>
    {
        public EnrollmentDtoValidator (ICourseRepository courseRepository, IStudentRepository studentRepository) 
        {
            Include(new CreateEnrollmenDtoValidator(courseRepository, studentRepository));
        }  
    }
}
