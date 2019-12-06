using System.Threading.Tasks;
using Campus.Application.LectorSubjects.Queries.GetAllLectorsSubjects;
using Microsoft.AspNetCore.Mvc;

namespace Campus.WebUI.Controllers
{
    public class LectorSubjectController : BaseController
    {
        [HttpGet("lector/{id}")]
        public async Task<IActionResult> GetByLectorId(int id)
        {
            return Ok(await Mediator.Send(new GetAllLectorsSubjectsQuery { LectorId = id }));
        }
    }
}