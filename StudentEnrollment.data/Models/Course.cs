namespace StudentEnrollment.data.Models
{
    public class Course : BaseEnitiy
    {
        public string? Title { get; set; }
        public int Credits { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}