using System;
using System.Linq.Expressions;

using Campus.Domain.Entities;

namespace Campus.Application.Lectors.Queries.GetLectorDetail
{
    public class LectorDetailModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int AcademicDegreeId { get; set; }
        public string AcademicDegreeName { get; set; }
        public int AcademicRankId { get; set; }
        public string AcademicRankName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static Expression<Func<Lector, LectorDetailModel>> Projection
        {
            get
            {
                return x => new LectorDetailModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Patronymic = x.Patronymic,
                    AcademicDegreeId  = x.AcademicDegreeId,
                    AcademicDegreeName = x.AcademicDegree!=null?x.AcademicDegree.Name:string.Empty,
                    AcademicRankId = x.AcademicRankId,
                    AcademicRankName = x.AcademicRank!=null?x.AcademicRank.Name:string.Empty,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber
                };
            }
        }
    }
}
