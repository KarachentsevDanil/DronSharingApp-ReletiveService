using RCS.BLL.Services.Contracts;
using RCS.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCS.Domain.Params;
using RCS.BLL.Dto.Facilities;
using RCS.WebApi.Extensions;

namespace RCS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DrugController : Controller
    {
        private readonly IDrugService _drugService;

        public DrugController(IDrugService drugService)
        {
            _drugService = drugService;
        }

        [HttpPost]
        public IActionResult AddDrug([FromBody]AddDrugDto drugDto)
        {
            _drugService.AddDrug(drugDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetDrugs([FromBody] DrugsFilterParams filterParams)
        {
            var items = _drugService.GetDrugsByParams(filterParams);

            return Json(JsonResultData.Success(items));
        }

        [HttpGet]
        public IActionResult GetDrugsByTerm(string term)
        {
            var userModel = User.GetUserModel();
            var items = _drugService.GetDrugsByTerm(term ?? string.Empty);
            return Json(JsonResultData.Success(items));
        }
    }
}
