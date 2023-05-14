using FluentValidation;

namespace StudentEnroolment.API.Dtos.Student
{
    public class CreateStudentDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? IdNumber { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string OrignalFilename { get; set; }
    }
    public class CreateStudentDtoVaildator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentDtoVaildator()
        {
           RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.DateOfBirth)
                .NotEmpty();
            RuleFor(x => x.IdNumber)
                .NotEmpty();
            RuleFor(x => x.OrignalFilename)
                .NotNull()
                .When(x => x.ProfilePicture != null);
        }
    }
}   

