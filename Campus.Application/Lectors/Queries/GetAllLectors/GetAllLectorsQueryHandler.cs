using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using System.Linq;
using Campus.Application.Lectors.Queries.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace Campus.Application.Lectors.Queries.GetAllLectors
{
    public class GetAllLectorsQueryHandler : IRequestHandler<GetAllLectorsQuery, LectorsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllLectorsQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<LectorsListViewModel> Handle(GetAllLectorsQuery request, CancellationToken cancellationToken)
        {
            var model = new LectorsListViewModel();

            model.Lectors = await _context.Lectors.Include(x=>x.AcademicDegree).Include(x=>x.AcademicRank)
                                                  .Select(LectorDto.Projection).ToListAsync();

            return model;
        }
    }
}
