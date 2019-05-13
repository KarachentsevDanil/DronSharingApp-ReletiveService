using RCS.BLL.Services.Contracts;
using RCS.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCS.Domain.Params;
using RCS.BLL.Dto.Facilities;

namespace RCS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ManipulationController : Controller
    {
        private readonly IManipulationService _manipulationService;

        public ManipulationController(IManipulationService manipulationService)
        {
            _manipulationService = manipulationService;
        }

        [HttpPost]
        public IActionResult AddManipulation([FromBody]AddManipulationDto manipulationDto)
        {
            _manipulationService.AddManipulation(manipulationDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetFacilities([FromBody] ManipulationsFilterParams filterParams)
        {
            var items = _manipulationService.GetManipulationsByParams(filterParams);

            return Json(JsonResultData.Success(items));
        }
    }
}
