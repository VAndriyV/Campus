using System.Collections.Generic;

using Campus.Application.Groups.Queries.DataTransferObjects;

namespace Campus.Application.Groups.Queries.GetAllGroups
{
    public class GroupsListViewModel
    {
        public IList<GroupDto> Groups { get; set; }
    }
}
