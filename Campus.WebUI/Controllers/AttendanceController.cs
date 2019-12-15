using System;
using System.Threading.Tasks;
using Campus.Application.Attendances.Commands.CreateAttendance;
using Campus.Application.Attendances.Queries.GetAllAttendances;
using Campus.Application.Attendances.Queries.GetAllGroupsAttendances;
using Campus.Application.Attendances.Queries.GetAllLectorsAttendances;
using Microsoft.AspNetCore.Mvc;

namespace Campus.WebUI.Controllers
{
    public class AttendanceController : BaseController          
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAttendanceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<IActionResult> GetAll(DateTime startDate, DateTime endDate)
        {
            return Ok(await Mediator.Send(new GetAllAttendancesQuery { StartDate = startDate, EndDate = endDate }));
        }

        [HttpGet("group/{groupId}/{startDate}/{endDate}")]
        public async Task<IActionResult> GetAllByGroup(int groupId,DateTime startDate, DateTime endDate)
        {
            return Ok(await Mediator.Send(new GetAllGroupsAttendancesQuery { GroupId = groupId, StartDate = startDate, EndDate = endDate }));
        }

        [HttpGet("lector/{lectorId}/{startDate}/{endDate}")]
        public async Task<IActionResult> GetAllByLector(int lectorId, DateTime startDate, DateTime endDate)
        {
            return Ok(await Mediator.Send(new GetAllLectorsAttendancesQuery { LectorId = lectorId, StartDate = startDate, EndDate = endDate }));
        }
    }
}
