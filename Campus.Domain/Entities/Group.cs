using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecialityId { get; set; }
        public int EducationalDegreeId { get; set; }
        public int Year { get; set; }
        public int StudentsCount { get; set; }

        public Speciality Speciality { get; set; }
        public EducationalDegree EducationalDegree { get; set; }   
        public ICollection<Lesson> Lessons { get; set; }
    }
}
