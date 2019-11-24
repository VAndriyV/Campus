using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Application.User.Queries.DataTransferObjects;
using Campus.Persistence;

namespace Campus.Application.User.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly CampusDbContext _context;

        public GetUserQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
