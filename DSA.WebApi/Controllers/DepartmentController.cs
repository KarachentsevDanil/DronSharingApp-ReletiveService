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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetDepartmentsByTerm(string term)
        {
            var userModel = User.GetUserModel();
            var facilities = _departmentService.GetDepartmentsByTerm(userModel.FacilityId.Value, term ?? string.Empty);
            return Json(JsonResultData.Success(facilities));
        }

        [HttpPost]
        public IActionResult AddDepartment([FromBody]AddDepartmentDto departmentDto)
        {
            _departmentService.AddDepartment(departmentDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetDepartments([FromBody] DepartmentsFilterParams filterParams)
        {
            var userModel = User.GetUserModel();

            if (userModel.FacilityId.HasValue)
            {
                filterParams.FacilityId = userModel.FacilityId.Value;
            }

            var items = _departmentService.GetDepartmentsByParams(filterParams);

            return Json(JsonResultData.Success(items));
        }
    }
}
