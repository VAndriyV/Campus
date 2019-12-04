using MediatR;

using Campus.Application.Enumerations.Queries.Models;

namespace Campus.Application.Enumerations.Queries.GetAllLessonTypes
{
    public class GetAllLessonTypesQuery : IRequest<EnumerationItemsListViewModel>
    {
    }
}
