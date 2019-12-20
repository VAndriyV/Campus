using Campus.Application.Lectors.Commands.CreateLector;
using Campus.Application.Lectors.Commands.DeleteLector;
using Campus.Application.Lectors.Commands.UpdateLector;
using Campus.Application.Lectors.Queries.GetAllLectors;
using Campus.Application.Lectors.Queries.GetLectorDetail;
using Campus.Application.Notifications.Commands.SendPasswordToNewLector;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Campus.WebUI.Controllers
{
    public class LectorController : BaseController
    {        
        [HttpGet]
        public Task<LectorsListViewModel> GetAll()
        {
            return Mediator.Send(new GetAllLectorsQuery());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetLectorDetailQuery { Id = id }));
        }
       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLectorCommand command)
        {
            var (id,password) = await Mediator.Send(command);

            await Mediator.Send(new SendPasswordToNewLectorCommand { LectorId = id, Password = password });

            return CreatedAtAction("Get", new { id });
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateLectorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Lectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteLectorCommand { Id = id });

            return NoContent();
        }
    }
}
