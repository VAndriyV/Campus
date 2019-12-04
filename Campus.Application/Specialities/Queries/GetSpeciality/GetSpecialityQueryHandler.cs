using Campus.Application.Exceptions;
using Campus.Application.Specialities.Queries.DataTransferObjects;
using Campus.Domain.Entities;
using Campus.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.Specialities.Queries.GetSpeciality
{
    public class GetSpecialityQueryHandler : IRequestHandler<GetSpecialityQuery, SpecialityDto>
    {
        private readonly CampusDbContext _context;

        public GetSpecialityQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<SpecialityDto> Handle(GetSpecialityQuery request, CancellationToken cancellationToken)
        {
            var speciality = await _context.Specialities
                .Select(SpecialityDto.Projection)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (speciality == null)
            {
                throw new NotFoundException(nameof(Speciality), request.Id);
            }

            return speciality;
        }
    }
}
