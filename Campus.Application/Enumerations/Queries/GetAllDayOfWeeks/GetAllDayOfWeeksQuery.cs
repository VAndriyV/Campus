using MediatR;

using Campus.Application.Enumerations.Queries.Models;

namespace Campus.Application.Enumerations.Queries.GetAllDayOfWeeks
{
    public class GetAllDayOfWeeksQuery : IRequest<EnumerationItemsListViewModel>
    {
    }
}
