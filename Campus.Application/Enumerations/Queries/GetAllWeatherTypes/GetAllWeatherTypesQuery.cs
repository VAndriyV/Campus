using MediatR;

using Campus.Application.Enumerations.Queries.Models;

namespace Campus.Application.Enumerations.Queries.GetAllWeatherTypes
{
    public class GetAllWeatherTypesQuery : IRequest<EnumerationItemsListViewModel>
    {
    }
}
