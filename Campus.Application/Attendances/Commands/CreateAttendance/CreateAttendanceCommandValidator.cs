using FluentValidation;

namespace Campus.Application.Attendances.Commands.CreateAttendance
{
    public class CreateAttendanceCommandValidator : AbstractValidator<CreateAttendanceCommand>
    {
        public CreateAttendanceCommandValidator()
        {
            RuleFor(x => x.DayOfWeekId).NotEmpty();
            RuleFor(x => x.StudentsCount).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.LessonId).NotEmpty();
            RuleFor(x => x.WeatherTypeId).NotEmpty();
        }
    }
}
