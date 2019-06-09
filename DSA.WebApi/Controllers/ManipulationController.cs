using RCS.BLL.Services.Contracts;
using RCS.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCS.BLL.Dto.Customers;
using RCS.Domain.Params;
using RCS.BLL.Dto.Facilities;
using RCS.WebApi.Extensions;

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
        public IActionResult GetManipulations([FromBody] ManipulationsFilterParams filterParams)
        {
            UserDto user = User.GetUserModel();

            if (user.FacilityId.HasValue)
            {
                filterParams.FacilityId = user.FacilityId.Value;
            }

            var items = _manipulationService.GetManipulationsByParams(filterParams);

            return Json(JsonResultData.Success(items));
        }

        [HttpGet]
        public IActionResult GetManipulationsByTerm(string term)
        {
            var userModel = User.GetUserModel();
            var items = _manipulationService.GetManipulationsByTerm(userModel.FacilityId.Value, term ?? string.Empty);
            return Json(JsonResultData.Success(items));
        }
    }
}
