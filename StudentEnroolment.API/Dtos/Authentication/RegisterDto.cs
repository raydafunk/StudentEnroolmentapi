namespace StudentEnroolment.API.Dtos.Authentication
{
    public class RegisterDto : LoginDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
