using MediatR;

namespace Campus.Application.Lectors.Queries.GetAllLectors
{
    public class GetAllLectorsQuery : IRequest<LectorsListViewModel>
    {
    }
}
