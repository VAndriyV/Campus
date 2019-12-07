using Campus.Application.Exceptions;
using Campus.Application.LectorSubjects.Queries.DataTransferObjects;
using Campus.Domain.Entities;
using Campus.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.LectorSubjects.Queries.GetLectorSubjectQuery
{
    public class GetLectorSubjectQueryHandler : IRequestHandler<GetLectorSubjectQuery, LectorSubjectDto> 
    {
        private readonly CampusDbContext _context;

        public GetLectorSubjectQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<LectorSubjectDto> Handle(GetLectorSubjectQuery request, CancellationToken cancellationToken)
        {
            var lectorSubject = await _context.LectorSubjects
                .Select(LectorSubjectDto.Projection)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (lectorSubject == null)
            {
                throw new NotFoundException(nameof(LectorSubject), request.Id);
            }

            return lectorSubject;
        }
    }
}
