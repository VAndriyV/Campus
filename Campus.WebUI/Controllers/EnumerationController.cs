using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Campus.Application.Enumerations.Queries.GetAllWeatherTypes;
using Campus.Application.Enumerations.Queries.Models;
using Campus.Application.Enumerations.Queries.GetAllAcademicRanks;
using Campus.Application.Enumerations.Queries.GetAllDayOfWeeks;
using Campus.Application.Enumerations.Queries.GetAllEducationalDegrees;
using Campus.Application.Enumerations.Queries.GetAllLessonTypes;
using Campus.Application.Enumerations.Queries.GetAllAcademicDegrees;

namespace Campus.WebUI.Controllers
{
    public class EnumerationController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<EnumerationItemsListViewModel>> WeatherType()
        {
            return Ok(await Mediator.Send(new GetAllWeatherTypesQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<EnumerationItemsListViewModel>> AcademicRank()
        {
            return Ok(await Mediator.Send(new GetAllAcademicRanksQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<EnumerationItemsListViewModel>> AcademicDegree()
        {
            return Ok(await Mediator.Send(new GetAllAcademicDegreesQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<EnumerationItemsListViewModel>> DayOfWeek()
        {
            return Ok(await Mediator.Send(new GetAllDayOfWeeksQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<EnumerationItemsListViewModel>> EducationalDegree()
        {
            return Ok(await Mediator.Send(new GetAllEducationalDegreesQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<EnumerationItemsListViewModel>> LessonType()
        {
            return Ok(await Mediator.Send(new GetAllLessonTypesQuery()));
        }
    }
}