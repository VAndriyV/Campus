using MediatR;

namespace Campus.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecialityId { get; set; }
        public int EducationalDegreeId { get; set; }
        public int Year { get; set; }
        public int StudentsCount { get; set; }
    }
}
