using System.Collections.Generic;

using Campus.Application.Subjects.Queries.DataTransferObjects;

namespace Campus.Application.Subjects.Queries.GetAllSubjects
{
    public class SubjectsListViewModel
    {
        public IList<SubjectDto> Subjects { get; set; }
    }
}
