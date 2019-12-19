using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;
using Campus.Infrastructure.Helpers.Interfaces;

namespace Campus.Application.Lectors.Commands.CreateLector
{
    public class CreateLectorCommandHandler : IRequestHandler<CreateLectorCommand, int>
    {
        private readonly CampusDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IPasswordGenerator _passwordGenerator;

        public CreateLectorCommandHandler(CampusDbContext context, IPasswordHasher passwordHasher,
                                        IPasswordGenerator passwordGenerator)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _passwordGenerator = passwordGenerator;
        }

        public async Task<int> Handle(CreateLectorCommand request, CancellationToken cancellationToken)
        {
            var isEmailExist = await _context.Lectors.AnyAsync(x => x.Email == request.Email);
            
            if (isEmailExist)
            {
                throw new DuplicateException(nameof(Lector), "Email", request.Email);
            }

            var user = new User
            {
                Email = request.Email,
                PasswordHash = _passwordHasher.HashPassword(_passwordGenerator.GetRandomAlphanumericString())
            };

            _context.Users.Add(user);

            var userRole = new UserRole
            {
                RoleId = 1,
                User = user
            };

            _context.UserRoles.Add(userRole);

            var lector = new Lector
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                AcademicDegreeId = request.AcademicDegreeId,
                AcademicRankId = request.AcademicRankId,
                User = user
            };

            _context.Lectors.Add(lector);

            await _context.SaveChangesAsync(cancellationToken);

            return lector.Id;
        }
    }
}
