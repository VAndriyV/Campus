using System.Threading.Tasks;
using Campus.Application.Subjects.Commands.CreateSubject;
using Campus.Application.Subjects.Commands.DeleteSubject;
using Campus.Application.Subjects.Commands.UpdateSubject;
using Campus.Application.Subjects.Queries.GetAllSubjects;
using Campus.Application.Subjects.Queries.GetSubject;
using Microsoft.AspNetCore.Mvc;

namespace Campus.WebUI.Controllers
{
    public class SubjectController : BaseController
    {
        // GET: api/Subjects
        [HttpGet]
        public Task<SubjectsListViewModel> GetAll()
        {
            return Mediator.Send(new GetAllSubjectsQuery());
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]       
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSubjectQuery { Id = id }));
        }

        // POST: api/Subjects
        [HttpPost]       
        public async Task<IActionResult> Create([FromBody] CreateSubjectCommand command)
        {
            var productId = await Mediator.Send(command);

            return CreatedAtAction("GetSubject", new { id = productId });
        }

        // PUT: api/Subjects/5
        [HttpPut("{id}")]        
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateSubjectCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]        
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSubjectCommand { Id = id });

            return NoContent();
        }
    }
}