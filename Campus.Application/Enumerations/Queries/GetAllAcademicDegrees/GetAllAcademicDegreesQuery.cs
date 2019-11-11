using MediatR;

using Campus.Application.Enumerations.Queries.Models;

namespace Campus.Application.Enumerations.Queries.GetAllAcademicDegrees
{
    public class GetAllAcademicDegreesQuery : IRequest<EnumerationItemsListViewModel>
    {
    }
}
