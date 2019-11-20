using MediatR;

namespace Campus.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
