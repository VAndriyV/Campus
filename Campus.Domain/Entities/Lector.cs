using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class Lector
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int AcamedicDegreeId { get; set; }
        public int AcademicRankId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int UserId { get; set; }

        public AcademicDegree AcademicDegree { get; set; }
        public AcademicRank AcademicRank { get; set; }
        public User User { get; set; }
        public ICollection<LectorSubject> LectorSubjects { get; set; }
    }
}
