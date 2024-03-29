﻿namespace StudentEnrollment.data.Models
{
    public class Student : BaseEnitiy
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? IdNumber { get; set; }
        public string Picture { get; set; }

        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}