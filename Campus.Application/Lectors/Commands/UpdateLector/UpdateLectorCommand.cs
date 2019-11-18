using MediatR;

namespace Campus.Application.Lectors.Commands.UpdateLector
{
    public class UpdateLectorCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int AcademicDegreeId { get; set; }
        public int AcademicRankId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
