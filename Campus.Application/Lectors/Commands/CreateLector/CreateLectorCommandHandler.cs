using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Domain.Entities;
using Campus.Infrastructure.Helpers;
using System;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;

namespace Campus.Application.Lectors.Commands.CreateLector
{
    public class CreateLectorCommandHandler : IRequestHandler<CreateLectorCommand, int>
    {
        private readonly CampusDbContext _context;
        private readonly PasswordHasher _passwordHasher;
        private readonly PasswordGenerator _passwordGenerator;

        public CreateLectorCommandHandler(CampusDbContext context, PasswordHasher passwordHasher,
                                         PasswordGenerator passwordGenerator)
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
               // PasswordHash = _passwordHasher.HashPassword(_passwordGenerator.GetRandomAlphanumericString())   
               PasswordHash = _passwordHasher.HashPassword("testPassword123")
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
