using MediatR;

namespace Campus.Application.Specialities.Commands.UpdateSpeciality
{
    public class UpdateSpecialityCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
