using MediatR;

namespace Campus.Application.LectorSubjects.Commands.DeleteLectorSubject
{
    public class DeleteLectorSubjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
