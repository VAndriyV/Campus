using Campus.Application.Groups.Queries.DataTransferObjects;
using System.Collections.Generic;

namespace Campus.Application.Groups.Queries.GetLectorsGroups
{
    public class LectorsGroupsListViewModel
    {
        public IList<GroupDto> Groups { get; set; }
    }
}
