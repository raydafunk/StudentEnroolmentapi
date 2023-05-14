using FluentValidation;

namespace StudentEnroolment.API.Dtos.Student
{
    public class StudentDto : CreateStudentDto
    {
        public int Id { get; set; }
    }
    public class StudentDtoValidator : AbstractValidator<StudentDto>
    {
        public StudentDtoValidator() 
        {
          Include(new CreateStudentDtoVaildator());
        }    
    }
}
