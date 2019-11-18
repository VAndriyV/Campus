using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Lectors.Queries.GetLectorDetail
{
    public class GetLectorDetailQueryHandler : IRequestHandler<GetLectorDetailQuery, LectorDetailModel>
    {
        private readonly CampusDbContext _context;

        public GetLectorDetailQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<LectorDetailModel> Handle(GetLectorDetailQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
