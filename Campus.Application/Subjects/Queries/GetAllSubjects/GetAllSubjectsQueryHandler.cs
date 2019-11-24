using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Campus.Persistence;
using System.Linq;
using Campus.Application.Subjects.Queries.DataTransferObjects;

namespace Campus.Application.Subjects.Queries.GetAllSubjects
{
    public class GetAllSubjectsQueryHandler : IRequestHandler<GetAllSubjectsQuery, SubjectsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllSubjectsQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<SubjectsListViewModel> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            var model = new SubjectsListViewModel();

            model.Subjects = await _context.Subjects.Select(SubjectDto.Projection).ToListAsync();

            return model;
        }
    }
}
