namespace StudentEnroolment.API.Dtos.CourseDto
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public int Credits { get; set; }
    }
    public class CreatueCourseDto
    {
        public string? Title { get; set; }
        public int Credits { get; set; }
    }

}
