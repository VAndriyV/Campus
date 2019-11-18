using MediatR;

namespace Campus.Application.Lectors.Queries.GetLectorDetail
{
    public class GetLectorDetailQuery : IRequest<LectorDetailModel>
    {
        public int Id { get; set; }
    }
}
