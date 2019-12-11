using System.Threading.Tasks;
using Campus.Application.Lessons.Commands.CreateLesson;
using Campus.Application.Lessons.Queries.GetAllGroupsLessons;
using Campus.Application.Lessons.Queries.GetAllLectorsLessons;
using Campus.Application.Lessons.Queries.GetLectorsLessonsByGroup;
using Campus.Application.Lessons.Queries.GetLesson;
using Microsoft.AspNetCore.Mvc;

namespace Campus.WebUI.Controllers
{
    public class LessonController : BaseController
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLesson(int id)
        {
            return Ok(await Mediator.Send(new GetLessonQuery { Id = id }));
        }

        [HttpGet("lector/{id}")]
        public async Task<IActionResult> GetByLectorId(int id)
        {
            return Ok(await Mediator.Send(new GetAllLectorsLessonsQuery { LectorId = id }));
        }

        [HttpGet("group/{id}")]
        public async Task<IActionResult> GetByGroupId(int id)
        {
            return Ok(await Mediator.Send(new GetAllGroupsLessonsQuery { GroupId = id }));
        }

        [HttpGet("lector/{lectorId}/group/{groupId}")]
        public async Task<IActionResult> GetByLectorIdAndGroupId(int lectorId, int groupId)
        {
            return Ok(await Mediator.Send(new GetLectorsLessonsByGroupQuery { LectorId = lectorId, GroupId = groupId }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLessonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}