using MediatR;

namespace Campus.Application.LectorSubjects.Queries.GetAllLectorsSubjects
{
    public class GetAllLectorsSubjectsQuery : IRequest<LectorsSubjectsListViewModel>
    {
        public int LectorId { get; set; }
    }
}
