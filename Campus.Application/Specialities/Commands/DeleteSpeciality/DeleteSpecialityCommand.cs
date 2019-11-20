using MediatR;

namespace Campus.Application.Specialities.Commands.DeleteSpeciality
{
    public class DeleteSpecialityCommand :IRequest
    {
        public int Id { get; set; }
    }
}
