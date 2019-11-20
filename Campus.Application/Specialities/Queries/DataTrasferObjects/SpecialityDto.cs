using System;
using System.Linq.Expressions;

using Campus.Domain.Entities;

namespace Campus.Application.Specialities.Queries.DataTransferObjects
{
    public class SpecialityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public static Expression<Func<Speciality, SpecialityDto>> Projection
        {
            get
            {
                return x=> new SpecialityDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code
                };
            }
        }
    }
}
