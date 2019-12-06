using System.Collections.Generic;

using Campus.Application.LectorSubjects.Queries.DataTransferObjects;

namespace Campus.Application.LectorSubjects.Queries.GetAllLectorsSubjects
{
    public class LectorsSubjectsListViewModel
    {
        public IList<LectorSubjectDto> LectorsSubjects { get; set; }
    }
}
