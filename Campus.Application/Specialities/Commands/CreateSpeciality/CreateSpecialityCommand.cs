using MediatR;

namespace Campus.Application.Specialities.Commands.CreateSpeciality
{
    public class CreateSpecialityCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
