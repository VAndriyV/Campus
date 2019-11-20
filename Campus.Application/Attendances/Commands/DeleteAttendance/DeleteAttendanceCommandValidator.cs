using FluentValidation;

namespace Campus.Application.Attendances.Commands.DeleteAttendance
{
    public class DeleteAttendanceCommandValidator : AbstractValidator<DeleteAttendanceCommand>
    {
        public DeleteAttendanceCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
