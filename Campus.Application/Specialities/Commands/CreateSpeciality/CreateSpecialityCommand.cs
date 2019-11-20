using MediatR;

namespace Campus.Application.Specialities.Commands.CreateSpeciality
{
    public class CreateSpecialityCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
