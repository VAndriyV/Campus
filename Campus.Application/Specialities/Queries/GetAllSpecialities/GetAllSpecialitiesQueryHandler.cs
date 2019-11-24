using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Campus.Persistence;

using Campus.Application.Specialities.Queries.DataTransferObjects;

namespace Campus.Application.Specialities.Queries.GetAllSpecialities
{
    public class GetAllSpecialitiesQueryHandler : IRequestHandler<GetAllSpecialitiesQuery, SpecialitiesListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllSpecialitiesQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<SpecialitiesListViewModel> Handle(GetAllSpecialitiesQuery request, CancellationToken cancellationToken)
        {
            var model = new SpecialitiesListViewModel();

            model.Specialities = await _context.Specialities.Select(SpecialityDto.Projection).ToListAsync();

            return model;
        }
    }
}
