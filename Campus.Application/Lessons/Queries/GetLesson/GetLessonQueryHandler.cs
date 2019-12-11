using Campus.Application.Exceptions;
using Campus.Application.Lessons.Queries.DataTransferObjects;
using Campus.Domain.Entities;
using Campus.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.Lessons.Queries.GetLesson
{
    public class GetLessonQueryHandler : IRequestHandler<GetLessonQuery, LessonDto>
    {
        private readonly CampusDbContext _context;

        public GetLessonQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<LessonDto> Handle(GetLessonQuery request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons
                .Where(x => x.Id == request.Id)
                .Include(x=>x.LectorSubject)
                .Select(LessonDto.Projection)
                .SingleOrDefaultAsync();

            if(lesson == null)
            {
                throw new NotFoundException(nameof(Lesson), request.Id);
            }

            return lesson;
        }
    }
}
