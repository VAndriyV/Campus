using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Campus.Application.Enumerations.Queries.Models;
using Campus.Persistence;

namespace Campus.Application.Enumerations.Queries.GetAllEducationalDegrees
{
    public class GetAllEducationalDegreesQueryHandler : IRequestHandler<GetAllEducationalDegreesQuery, EnumerationItemsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllEducationalDegreesQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<EnumerationItemsListViewModel> Handle(GetAllEducationalDegreesQuery request, CancellationToken cancellationToken)
        {
            var result = new EnumerationItemsListViewModel();

            result.Items = await _context.EducationalDegrees.Select(x => new EnumerationItem { Id = x.Id, Name = x.Name }).ToListAsync();

            return result;
        }
    }
}
