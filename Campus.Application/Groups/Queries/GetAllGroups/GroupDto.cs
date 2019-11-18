using System;
using System.Linq.Expressions;

using Campus.Domain.Entities;

namespace Campus.Application.Groups.Queries.GetAllGroups
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
        public int? SpecialityCode { get; set; }
        public int EducationalDegreeId { get; set; }
        public string EducationalDegreeName { get; set; }
        public int Year { get; set; }
        public int StudentsCount { get; set; }

        public static Expression<Func<Group, GroupDto>> Projection
        {
            get
            {
                return x => new GroupDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    SpecialityId = x.SpecialityId,
                    SpecialityName = x.Speciality != null ? x.Speciality.Name : string.Empty,
                    SpecialityCode = x.Speciality != null ? x.Speciality.Code : default(int?),
                    EducationalDegreeId = x.EducationalDegreeId,
                    EducationalDegreeName = x.EducationalDegree != null ? x.EducationalDegree.Name : string.Empty,
                    Year = x.Year,
                    StudentsCount = x.StudentsCount
                };
            }
        }
    }
}
