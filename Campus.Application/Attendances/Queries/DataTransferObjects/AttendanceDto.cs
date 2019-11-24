using System;
using System.Linq.Expressions;

using Campus.Domain.Entities;

namespace Campus.Application.Attendances.Queries.DataTransferObjects
{
    public class AttendanceDto
    {
        public Expression<Func<Attendance, AttendanceDto>> Projection
        {
            get
            {
                return x => new AttendanceDto
                {

                };
            }
        }
    }
}
