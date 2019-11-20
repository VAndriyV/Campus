using System.Collections.Generic;

using Campus.Application.Lessons.Queries.DataTransferObjects;

namespace Campus.Application.Lessons.Queries.GetAllGroupsLessons
{
    public class GroupsLessonsListViewModel
    {
        public int GroupId { get; set; }
        public int GroupName { get; set; }
        public IList<LessonDto> Lessons { get; set; }
    }
}
