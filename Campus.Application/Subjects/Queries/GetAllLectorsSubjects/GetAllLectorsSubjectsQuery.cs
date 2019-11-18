using MediatR;

namespace Campus.Application.Subjects.Queries.GetAllLectorsSubjects
{
    public class GetAllLectorsSubjectsQuery : IRequest<LectorsSubjectsListViewModel>
    {
        public int LectorId { get; set; }
    }
}
