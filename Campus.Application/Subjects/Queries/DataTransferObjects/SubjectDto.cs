using System;
using System.Linq.Expressions;

using Campus.Domain.Entities;
namespace Campus.Application.Subjects.Queries.DataTransferObjects
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Subject, SubjectDto>> Projection
        {
            get
            {
                return x => new SubjectDto
                {
                    Id = x.Id,
                    Name = x.Name
                };
            }
        }
    }
}
