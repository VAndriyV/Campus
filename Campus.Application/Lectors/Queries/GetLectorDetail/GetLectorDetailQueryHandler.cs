using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Lectors.Queries.GetLectorDetail
{
    public class GetLectorDetailQueryHandler : IRequestHandler<GetLectorDetailQuery, LectorDetailModel>
    {
        private readonly CampusDbContext _context;

        public GetLectorDetailQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<LectorDetailModel> Handle(GetLectorDetailQuery request, CancellationToken cancellationToken)
        {
            var lector = await _context.Lectors
                .Where(x => x.Id == request.Id)
                .Include(x => x.AcademicRank)
                .Include(x => x.AcademicDegree)
                .Select(LectorDetailModel.Projection)
                .SingleOrDefaultAsync();

            if(lector == null)
            {
                throw new NotFoundException(nameof(Lector), request.Id);
            }

            return lector;
        }
    }
}
