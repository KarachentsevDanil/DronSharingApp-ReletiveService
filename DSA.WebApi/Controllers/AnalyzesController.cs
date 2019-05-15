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
    public class AnalyzesController : Controller
    {
        private readonly IAnalyzesService _analyzesService;

        public AnalyzesController(IAnalyzesService analyzesService)
        {
            _analyzesService = analyzesService;
        }

        [HttpPost]
        public IActionResult AddAnalyzes([FromBody]AddAnalyzesDto analyzesDto)
        {
            _analyzesService.AddAnalyzes(analyzesDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetAnalyzes([FromBody] AnalyzesFilterParams filterParams)
        {
            UserDto user = User.GetUserModel();

            if (user.FacilityId.HasValue)
            {
                filterParams.FacilityId = user.FacilityId.Value;
            }

            var items = _analyzesService.GetAnalyzesByParams(filterParams);

            return Json(JsonResultData.Success(items));
        }
    }
}
