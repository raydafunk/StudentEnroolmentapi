using AutoMapper;
using StudentEnrollment.data.Models;
using StudentEnroolment.API.Dtos.CourseDto;

namespace StudentEnroolment.API.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
