using System.Collections.Generic;

using Campus.Application.Subjects.Queries.DataTransferObjects;

namespace Campus.Application.Subjects.Queries.GetAllGroupsSubjects
{
    public class GroupsSubjectsListViewModel
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public IList<SubjectDto> Subjects { get; set; }
    }
}
