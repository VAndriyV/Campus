using MediatR;

namespace Campus.Application.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
