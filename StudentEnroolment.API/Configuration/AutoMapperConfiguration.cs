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
            //course mappings
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, CourseDetailsDto>()
                .ForMember(q => q.Students, x => x.MapFrom(course => course.Enrollments.Select(stu => stu.Student)));

            //Studen mappings
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, StudentDetailsDto>()
                .ForMember(q => q.Courses, x => x.MapFrom(student => student.Enrollments.Select(course => course.Course)));

            //enrollment mappings
            CreateMap<Enrollment, Enrollment>().ReverseMap();
            CreateMap<Enrollment, CreateEnrollmenDto>().ReverseMap();
        }
    }
}
