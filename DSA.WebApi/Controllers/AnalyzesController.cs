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
        public IActionResult GetFacilities([FromBody] AnalyzesFilterParams filterParams)
        {
            var items = _analyzesService.GetAnalyzesByParams(filterParams);

            return Json(JsonResultData.Success(items));
        }
    }
}
