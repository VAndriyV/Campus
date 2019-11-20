using System.Collections.Generic;

using Campus.Application.Lectors.Queries.DataTransferObjects;

namespace Campus.Application.Lectors.Queries.GetAllLectors
{
    public class LectorsListViewModel
    {
        public IList<LectorDto> Lectors { get; set; }
    }
}
