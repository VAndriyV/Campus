using MediatR;
using Campus.Application.Specialities.Queries.DataTransferObjects;

namespace Campus.Application.Specialities.Queries.GetSpeciality
{
    public class GetSpecialityQuery : IRequest<SpecialityDto>
    {
        public int Id { get; set; }
    }
}
