using MediatR;

namespace Campus.Application.Attendances.Commands.DeleteAttendance
{
    public class DeleteAttendanceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
