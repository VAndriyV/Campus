using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Application.Attendances.Queries.GetAllAttendances
{
    public class GetAllAttendancesQueryValidator : AbstractValidator<GetAllAttendancesQuery>
    {
        public GetAllAttendancesQueryValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();

            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate);
        }
    }
}
