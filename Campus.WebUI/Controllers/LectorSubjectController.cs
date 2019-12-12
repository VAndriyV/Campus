using System.Threading.Tasks;
using Campus.Application.LectorSubjects.Commands.CreateLectorSubject;
using Campus.Application.LectorSubjects.Commands.DeleteLectorSubject;
using Campus.Application.LectorSubjects.Commands.UpdateLectorSubject;
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
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLectorSubjectCommand command)
        {
            var productId = await Mediator.Send(command);

            return CreatedAtAction("Get", new { id = productId });
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateLectorSubjectCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteLectorSubjectCommand { Id = id });

            return NoContent();
        }
    }
}