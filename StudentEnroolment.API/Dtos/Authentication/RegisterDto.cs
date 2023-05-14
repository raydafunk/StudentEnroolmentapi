using FluentValidation;

namespace StudentEnroolment.API.Dtos.Authentication
{
    public class RegisterDto : LoginDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
    public class RegisterDtoVaildator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoVaildator()
        {
            Include(new  LoginDtoValidotor());

            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.DateOfBirth)
                 .Must((dob) =>
                 {
                     if (dob.HasValue)
                     {
                         return dob.Value < DateTime.Now;
                     }
                     return true;
                 });
        }
    }
}
