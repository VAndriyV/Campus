using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Specialities.Queries.GetAllSpecialities
{
    public class GetAllSpecialitiesQueryHandler : IRequestHandler<GetAllSpecialitiesQuery, SpecialitiesListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllSpecialitiesQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<SpecialitiesListViewModel> Handle(GetAllSpecialitiesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
