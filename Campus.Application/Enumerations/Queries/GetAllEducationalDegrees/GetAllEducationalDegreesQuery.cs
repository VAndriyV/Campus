using MediatR;

using Campus.Application.Enumerations.Queries.Models;

namespace Campus.Application.Enumerations.Queries.GetAllEducationalDegrees
{
    public class GetAllEducationalDegreesQuery : IRequest<EnumerationItemsListViewModel>
    {
    }
}
