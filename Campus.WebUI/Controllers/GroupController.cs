using System.Threading.Tasks;
using Campus.Application.Groups.Commands.CreateGroup;
using Campus.Application.Groups.Commands.DeleteGroup;
using Campus.Application.Groups.Commands.UpdateGroup;
using Campus.Application.Groups.Queries.GetAllGroups;
using Campus.Application.Groups.Queries.GetGroupDetail;
using Microsoft.AspNetCore.Mvc;

namespace Campus.WebUI.Controllers
{
    public class GroupController : BaseController
    {
        // GET: api/Groups
        [HttpGet]
        public Task<GroupsListViewModel> GetAll()
        {
            return Mediator.Send(new GetAllGroupsQuery());
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetGroupDetailQuery { Id = id }));
        }

        // POST: api/Groups
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGroupCommand command)
        {
            var productId = await Mediator.Send(command);

            return CreatedAtAction("GetGroup", new { id = productId });
        }

        // PUT: api/Groups/5
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

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGroupCommand { Id = id });

            return NoContent();
        }
    }
}