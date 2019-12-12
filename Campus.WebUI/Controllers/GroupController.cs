using System.Threading.Tasks;
using Campus.Application.Groups.Commands.CreateGroup;
using Campus.Application.Groups.Commands.DeleteGroup;
using Campus.Application.Groups.Commands.UpdateGroup;
using Campus.Application.Groups.Queries.GetAllGroups;
using Campus.Application.Groups.Queries.GetGroupDetail;
using Campus.Application.Groups.Queries.GetLectorsGroups;
using Microsoft.AspNetCore.Mvc;

namespace Campus.WebUI.Controllers
{
    public class GroupController : BaseController
    {        
        [HttpGet]
        public Task<GroupsListViewModel> GetAll()
        {
            return Mediator.Send(new GetAllGroupsQuery());
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetGroupDetailQuery { Id = id }));
        }

        [HttpGet("lector/{id}")]
        public async Task<IActionResult> GetByLectorId(int id)
        {
            return Ok(await Mediator.Send(new GetLectorsGroupsQuery { LectorId = id }));
        }
      
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGroupCommand command)
        {
            var productId = await Mediator.Send(command);

            return CreatedAtAction("Get", new { id = productId });
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateGroupCommand command)
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
            await Mediator.Send(new DeleteGroupCommand { Id = id });

            return NoContent();
        }
    }
}