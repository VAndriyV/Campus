using MediatR;

namespace Campus.Application.Groups.Queries.GetGroupDetail
{
    public class GetGroupDetailQuery : IRequest<GroupDetailModel>
    {
        public int Id { get; set; }
    }
}
