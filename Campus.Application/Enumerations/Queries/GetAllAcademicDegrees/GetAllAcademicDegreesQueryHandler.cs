using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Campus.Application.Enumerations.Queries.Models;
using Campus.Persistence;

namespace Campus.Application.Enumerations.Queries.GetAllAcademicDegrees
{
    public class GetAllAcademicDegreesQueryHandler : IRequestHandler<GetAllAcademicDegreesQuery, EnumerationItemsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllAcademicDegreesQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<EnumerationItemsListViewModel> Handle(GetAllAcademicDegreesQuery request, CancellationToken cancellationToken)
        {
            var result = new EnumerationItemsListViewModel();

            result.Items = await _context.AcademicDegrees.Select(x => new EnumerationItem { Id = x.Id, Name = x.Name }).ToListAsync();

            return result;
        }
    }
}
