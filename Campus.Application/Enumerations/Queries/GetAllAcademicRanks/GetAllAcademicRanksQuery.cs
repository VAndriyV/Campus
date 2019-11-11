using MediatR;

using Campus.Application.Enumerations.Queries.Models;

namespace Campus.Application.Enumerations.Queries.GetAllAcademicRanks
{
    public class GetAllAcademicRanksQuery : IRequest<EnumerationItemsListViewModel>
    {
    }
}
