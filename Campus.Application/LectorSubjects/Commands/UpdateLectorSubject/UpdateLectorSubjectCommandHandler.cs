using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Microsoft.EntityFrameworkCore;
using Campus.Domain.Entities;
using Campus.Application.Exceptions;

namespace Campus.Application.LectorSubjects.Commands.UpdateLectorSubject
{
    public class UpdateLectorSubjectCommandHandler : IRequestHandler<UpdateLectorSubjectCommand, Unit>
    {
        private readonly CampusDbContext _context;
        public UpdateLectorSubjectCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLectorSubjectCommand request, CancellationToken cancellationToken)
        {
            var lectorSubject = await _context.LectorSubjects.FindAsync(request.Id);
            if(lectorSubject == null)
            {
                throw new NotFoundException(nameof(LectorSubject), request.Id);
            }

            var isLectorSubjectExist = await _context.LectorSubjects.AnyAsync(x => x.Id != request.Id
                                                                             && x.LectorId == request.LectorId
                                                                             && x.SubjectId == request.SubjectId
                                                                             && x.LessonTypeId == request.LessonTypeId);
            if (isLectorSubjectExist)
            {
                throw new DuplicateException(nameof(LectorSubject));
            }

            lectorSubject.LectorId = request.LectorId;
            lectorSubject.SubjectId = request.SubjectId;
            lectorSubject.LessonTypeId = request.LessonTypeId;

            _context.LectorSubjects.Update(lectorSubject);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
