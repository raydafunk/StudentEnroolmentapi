using AutoMapper;
using StudentEnrollment.data.Models;
using StudentEnroolment.API.Dtos.Course;
using StudentEnroolment.API.Dtos.Enrollment;
using StudentEnroolment.API.Dtos.Student;

namespace StudentEnroolment.API.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CreatueCourseDto>().ReverseMap();

            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();

            CreateMap<Enrollment, Enrollment>().ReverseMap();
            CreateMap<Enrollment, CreateEnrollmenDto>().ReverseMap();
        }
    }
}
