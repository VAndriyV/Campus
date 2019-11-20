using MediatR;

namespace Campus.Application.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
