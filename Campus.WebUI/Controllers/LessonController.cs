using System.Threading.Tasks;
using Campus.Application.Lessons.Commands.CreateLesson;
using Campus.Application.Lessons.Queries.GetAllGroupsLessons;
using Campus.Application.Lessons.Queries.GetAllLectorsLessons;
using Microsoft.AspNetCore.Mvc;

namespace Campus.WebUI.Controllers
{
    public class LessonController : BaseController
    {
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLessonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}