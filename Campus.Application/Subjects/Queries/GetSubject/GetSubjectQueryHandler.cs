using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Application.Subjects.Queries.DataTransferObjects;
using Campus.Persistence;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Campus.Application.Subjects.Queries.GetSubject
{
    public class GetSubjectQueryHandler : IRequestHandler<GetSubjectQuery, SubjectDto>
    {
        private readonly CampusDbContext _context;

        public GetSubjectQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<SubjectDto> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
        {
            var subject = await _context.Subjects
                .Select(SubjectDto.Projection)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if(subject == null)
            {
                throw new NotFoundException(nameof(Subject), request.Id);
            }

            return subject;
        }
    }
}
