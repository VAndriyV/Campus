using System.Collections.Generic;

using Campus.Application.Specialities.Queries.DataTransferObjects;

namespace Campus.Application.Specialities.Queries.GetAllSpecialities
{
    public class SpecialitiesListViewModel
    {
        public IList<SpecialityDto> Specialities { get; set; }
    }
}
