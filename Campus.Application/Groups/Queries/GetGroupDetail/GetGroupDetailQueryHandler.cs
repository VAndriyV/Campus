using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Groups.Queries.GetGroupDetail
{
    public class GetGroupDetailQueryHandler : IRequestHandler<GetGroupDetailQuery, GroupDetailModel>
    {
        private readonly CampusDbContext _context;

        public GetGroupDetailQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<GroupDetailModel> Handle(GetGroupDetailQuery request, CancellationToken cancellationToken)
        {
            var group = await _context.Groups                
                .Where(x=>x.Id==request.Id)
                .Include(x=>x.Speciality)
                .Include(x=>x.EducationalDegree)
                .Select(GroupDetailModel.Projection)
                .SingleOrDefaultAsync(cancellationToken);

            if(group == null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            return group;
        }
    }
}
