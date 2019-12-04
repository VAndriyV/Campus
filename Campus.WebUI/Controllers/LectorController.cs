using Campus.Application.Lectors.Commands.CreateLector;
using Campus.Application.Lectors.Commands.DeleteLector;
using Campus.Application.Lectors.Commands.UpdateLector;
using Campus.Application.Lectors.Queries.GetAllLectors;
using Campus.Application.Lectors.Queries.GetLectorDetail;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Campus.WebUI.Controllers
{
    public class LectorController : BaseController
    {
        // GET: api/Lectors
        [HttpGet]
        public Task<LectorsListViewModel> GetAll()
        {
            return Mediator.Send(new GetAllLectorsQuery());
        }

        // GET: api/Lectors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetLectorDetailQuery { Id = id }));
        }

        // POST: api/Lectors
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLectorCommand command)
        {
            var productId = await Mediator.Send(command);

            return CreatedAtAction("GetLector", new { id = productId });
        }

        // PUT: api/Lectors/5
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
