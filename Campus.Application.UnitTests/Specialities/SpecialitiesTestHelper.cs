using Campus.Domain.Entities;
using Campus.Persistence;

namespace Campus.Application.UnitTests.Specialities
{
    static class SpecialitiesTestHelper
    {
        public static void LoadSpecialitiesTestData(CampusDbContext context)
        {
            context.Specialities.Add(new Speciality { Id = 1, Name = "Test Speciality 1", Code = 100 });
            context.Specialities.Add(new Speciality { Id = 2, Name = "Test Speciality 2", Code = 101 });

            context.EducationalDegrees.Add(new EducationalDegree { Id = 1, Name = "Educational Degree 1" });
            context.Groups.Add(new Group { Id = 1, EducationalDegreeId = 1, Name = "Group 1", SpecialityId = 2, StudentsCount = 10, Year = 1 });

            context.SaveChanges();
        }
    }
}
