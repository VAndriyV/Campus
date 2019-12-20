using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Application.Users.Queries.DataTransferObjects;
using Campus.Persistence;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;
using System.Linq;
using Campus.Application.Helpers.Interfaces;

namespace Campus.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly CampusDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public GetUserQueryHandler(CampusDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users               
                .SingleOrDefaultAsync(x => x.Email == request.Email);
            
            if(user == null)
            {
                throw new NotFoundException(nameof(User), request.Email);
            }

            if (!_passwordHasher.VerifyHashedPassword(user.PasswordHash, request.Password))
            {
                throw new InvalidPasswordException();
            }

            var userDto = new UserDto
            {
                Email = user.Email              
            };

            userDto.Roles = await _context.UserRoles
                .Include(x => x.Role)
                .Where(x => x.UserId == user.Id)
                .Select(x => x.Role.Name).ToListAsync();

            if (userDto.Roles.Contains("Lector"))
            {
                userDto.LectorId = (await _context.Lectors.SingleAsync(x => x.UserId == user.Id)).Id; 
            }

            return userDto;                
        }
    }
}
