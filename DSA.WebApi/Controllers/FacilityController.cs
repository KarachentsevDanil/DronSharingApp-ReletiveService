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
    public class FacilityController : Controller
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpPost]
        public IActionResult AddFacility([FromBody]AddFacilityDto facilityDto)
        {
            _facilityService.AddFacility(facilityDto);
            return Json(JsonResultData.Success());
        }

        [HttpGet]
        public IActionResult GetFacilitiesByTerm(string term)
        {
            var facilities = _facilityService.GetFacilitiesByTerm(term ?? string.Empty);
            return Json(JsonResultData.Success(facilities));
        }

        [HttpPost]
        public IActionResult GetFacilities([FromBody] FacilitiesFilterParams filterParams)
        {
            var facilities = _facilityService.GetFacilitiesByParams(filterParams);
            return Json(JsonResultData.Success(facilities));
        }
    }
}
