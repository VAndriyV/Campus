using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.LectorSubjects.Commands.CreateLectorSubject
{
    public class CreateLectorSubjectCommandHandler : IRequestHandler<CreateLectorSubjectCommand, int>
    {
        private readonly CampusDbContext _context;

        public CreateLectorSubjectCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLectorSubjectCommand request, CancellationToken cancellationToken)
        {
            var all = await _context.LectorSubjects.ToListAsync();

            var isLectorSubjectExist = await _context.LectorSubjects.AnyAsync(x => x.LectorId == request.LectorId
                                                                              && x.SubjectId == request.SubjectId
                                                                              && x.LessonTypeId == request.LessonTypeId);
            if (isLectorSubjectExist)
            {
                throw new DuplicateException(nameof(LectorSubject));
            }

            var lectorSubject = new LectorSubject
            {
                LectorId = request.LectorId,
                SubjectId = request.SubjectId,
                LessonTypeId = request.LessonTypeId
            };

            _context.LectorSubjects.Add(lectorSubject);

            await _context.SaveChangesAsync(cancellationToken);

            return lectorSubject.Id;
        }
    }
}
