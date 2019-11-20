using FluentValidation;

namespace Campus.Application.Attendances.Commands.UpdateAttendance
{
    public class UpdateAttendanceCommandValidator : AbstractValidator<UpdateAttendanceCommand>
    {
        public UpdateAttendanceCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.DayOfWeekId).NotEmpty();
            RuleFor(x => x.StudentsCount).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.LessonId).NotEmpty();
            RuleFor(x => x.WeatherTypeId).NotEmpty();
        }
    }
}
