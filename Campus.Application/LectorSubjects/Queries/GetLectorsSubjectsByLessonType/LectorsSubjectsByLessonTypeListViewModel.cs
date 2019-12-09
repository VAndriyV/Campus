using System.Collections.Generic;

using Campus.Application.LectorSubjects.Queries.DataTransferObjects;

namespace Campus.Application.LectorSubjects.Queries.GetLectorsSubjectsByLessonType
{
    public class LectorsSubjectsByLessonTypeListViewModel
    {
        public IList<SubjectInfo> LectorsSubjects { get; set; }
    }
}
