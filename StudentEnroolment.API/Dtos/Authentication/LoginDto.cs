using FluentValidation;

namespace StudentEnroolment.API.Dtos.Authentication
{
    public class LoginDto
    {
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
    }

    public class LoginDtoValidotor : AbstractValidator<LoginDto> 
    {
        public LoginDtoValidotor()
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .EmailAddress();  

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);



        }
    }
}
