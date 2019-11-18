using System.Collections.Generic;

using Campus.Application.Subjects.Queries.Models;

namespace Campus.Application.Subjects.Queries.GetAllLectorsSubjects
{
    public class LectorsSubjectsListViewModel
    {
        public string LectorId { get; set; }
        public string LectorName { get; set; }
        public IList<SubjectDto> Subjects { get; set; }
    }
}
