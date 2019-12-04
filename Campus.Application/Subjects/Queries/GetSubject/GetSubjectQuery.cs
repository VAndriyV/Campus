using MediatR;

using Campus.Application.Subjects.Queries.DataTransferObjects;

namespace Campus.Application.Subjects.Queries.GetSubject
{
    public class GetSubjectQuery : IRequest<SubjectDto>
    {
        public int Id { get; set; }
    }
}
