using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Campus.Application.Enumerations.Queries.Models;
using Campus.Persistence;

namespace Campus.Application.Enumerations.Queries.GetAllDayOfWeeks
{
    public class GetAllDayOfWeeksQueryHandler : IRequestHandler<GetAllDayOfWeeksQuery, EnumerationItemsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllDayOfWeeksQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<EnumerationItemsListViewModel> Handle(GetAllDayOfWeeksQuery request, CancellationToken cancellationToken)
        {
            var result = new EnumerationItemsListViewModel();

            result.Items = await _context.DayOfWeeks.Select(x => new EnumerationItem { Id = x.Id, Name = x.Name }).ToListAsync();

            return result;
        }
    }
}
