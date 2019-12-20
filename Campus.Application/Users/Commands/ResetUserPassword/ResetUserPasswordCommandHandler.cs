using Campus.Application.Exceptions;
using Campus.Application.Helpers.Interfaces;
using Campus.Domain.Entities;
using Campus.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.Users.Commands.ResetUserPassword
{
    public class ResetUserPasswordCommandHandler : IRequestHandler<ResetUserPasswordCommand, (int,string)>
    {
        private readonly CampusDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IPasswordGenerator _passwordGenerator;        

        public ResetUserPasswordCommandHandler(CampusDbContext context, IPasswordHasher passwordHasher,
                                               IPasswordGenerator passwordGenerator)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _passwordGenerator = passwordGenerator;            
        }

        public async Task<(int, string)> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == request.Email);
            
            if(user == null)
            {
                throw new NotFoundException(nameof(User), request.Email);
            }

            string password = _passwordGenerator.GetRandomAlphanumericString();

            user.PasswordHash = _passwordHasher.HashPassword(password);

            return (user.Id, password);
        }
    }
}
