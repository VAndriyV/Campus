using MediatR;
using Campus.Application.LectorSubjects.Queries.DataTransferObjects;

namespace Campus.Application.LectorSubjects.Queries.GetLectorSubjectQuery
{
    public class GetLectorSubjectQuery : IRequest<LectorSubjectDto>
    {
        public int Id { get; set; }
    }
}
