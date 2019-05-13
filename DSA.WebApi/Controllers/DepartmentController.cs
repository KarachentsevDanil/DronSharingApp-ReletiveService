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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public IActionResult AddDepartment([FromBody]AddDepartmentDto departmentDto)
        {
            _departmentService.AddDepartment(departmentDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetFacilities([FromBody] DepartmentsFilterParams filterParams)
        {
            var items = _departmentService.GetDepartmentsByParams(filterParams);

            return Json(JsonResultData.Success(items));
        }
    }
}
