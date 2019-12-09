using System.Threading.Tasks;
using Campus.Application.LectorSubjects.Queries.GetAllLectorsSubjects;
using Campus.Application.LectorSubjects.Queries.GetLectorsSubjectsByLessonType;
using Campus.Application.LectorSubjects.Queries.GetLectorSubjectQuery;
using Microsoft.AspNetCore.Mvc;

namespace Campus.WebUI.Controllers
{
    public class LectorSubjectController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetLectorSubjectQuery { Id = id }));
        }

        [HttpGet("lector/{id}")]
        public async Task<IActionResult> GetByLectorId(int id)
        {
            return Ok(await Mediator.Send(new GetAllLectorsSubjectsQuery { LectorId = id }));
        }

        [HttpGet("lector/{lectorId}/{lessonTypeId}")]
        public async Task<IActionResult> GetByLectorIdAndLessonTypeId(int lectorId, int lessonTypeId)
        {
            return Ok(await Mediator.Send(new GetLectorsSubjectsByLessonTypeQuery { LectorId = lectorId, LessonTypeId = lessonTypeId}));
        }
        
    }
}