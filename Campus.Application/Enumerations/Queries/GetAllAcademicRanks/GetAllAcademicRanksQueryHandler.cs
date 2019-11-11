using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Campus.Application.Enumerations.Queries.Models;
using Campus.Persistence;

namespace Campus.Application.Enumerations.Queries.GetAllAcademicRanks
{
    public class GetAllAcademicRanksQueryHandler : IRequestHandler<GetAllAcademicRanksQuery, EnumerationItemsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllAcademicRanksQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<EnumerationItemsListViewModel> Handle(GetAllAcademicRanksQuery request, CancellationToken cancellationToken)
        {
            var result = new EnumerationItemsListViewModel();

            result.Items = await _context.AcademicRanks.Select(x => new EnumerationItem { Id = x.Id, Name = x.Name }).ToListAsync();

            return result;
        }
    }
}
