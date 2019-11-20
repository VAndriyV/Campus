using System.Collections.Generic;

using Campus.Application.Lessons.Queries.DataTransferObjects;

namespace Campus.Application.Lessons.Queries.GetAllLectorsLessons
{
    public class LectorsLessonsListViewModel
    {
        public int LectorId { get; set; }
        public string LectorName { get; set; }
        public IList<LessonDto> Lessons { get; set; }
    }
}
