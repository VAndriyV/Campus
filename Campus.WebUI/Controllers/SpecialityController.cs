using System.Threading.Tasks;
using Campus.Application.Specialities.Commands.CreateSpeciality;
using Campus.Application.Specialities.Commands.DeleteSpeciality;
using Campus.Application.Specialities.Commands.UpdateSpeciality;
using Campus.Application.Specialities.Queries.GetAllSpecialities;
using Campus.Application.Specialities.Queries.GetSpeciality;
using Microsoft.AspNetCore.Mvc;

namespace Campus.WebUI.Controllers
{
    public class SpecialityController : BaseController
    {
        // GET: api/Specialitys
        [HttpGet]
        public Task<SpecialitiesListViewModel> GetAll()
        {
            return Mediator.Send(new GetAllSpecialitiesQuery());
        }

        // GET: api/Specialitys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSpecialityQuery { Id = id }));
        }

        // POST: api/Specialitys
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSpecialityCommand command)
        {
            var productId = await Mediator.Send(command);

            return CreatedAtAction("Get", new { id = productId });
        }

        // PUT: api/Specialitys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateSpecialityCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Specialitys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSpecialityCommand { Id = id });

            return NoContent();
        }
    }
}