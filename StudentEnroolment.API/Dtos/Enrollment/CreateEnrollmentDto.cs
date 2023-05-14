using FluentValidation;
using StudentEnrollment.data.Contracts.Interfaces.CouresInterface;
using StudentEnrollment.data.Contracts.Interfaces.StudentEnrollment;

namespace StudentEnroolment.API.Dtos.Enrollment
{
    public class CreateEnrollmentDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
    public class CreateEnrollmenDtoValidator:AbstractValidator<CreateEnrollmentDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        public CreateEnrollmenDtoValidator(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            this._courseRepository = courseRepository;
            this._studentRepository = studentRepository;

            RuleFor(x => x.CourseId)
                .MustAsync(async (id, token) =>
                {
                    var courseExists = await _courseRepository.ExitsAync(id); ;
                    return courseExists;
                }).WithMessage("{PropertyName} does not exist");
            RuleFor(x => x.StudentId)
                .MustAsync(async (id, token) =>
                {
                    var studentExists = await _studentRepository.ExitsAync(id); ;
                    return studentExists;
                }).WithMessage("{PropertyName} does not exist"); ;
        }
    }
}
