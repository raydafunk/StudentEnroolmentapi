namespace StudentEnrollment.data
{
    public class Student : BaseEnitiy
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string?  IdNumber { get; set; }
        public string? Picture { get; set; }
    }
}