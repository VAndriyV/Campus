using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Groups.Queries.GetGroupDetail
{
    public class GetGroupDetailQueryHandler : IRequestHandler<GetGroupDetailQuery, GroupDetailModel>
    {
        private readonly CampusDbContext _context;

        public GetGroupDetailQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<GroupDetailModel> Handle(GetGroupDetailQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
