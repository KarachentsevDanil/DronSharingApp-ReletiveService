using RCS.Domain.Params;
using RCS.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCS.BLL.Services.Contracts;
using RCS.BLL.Dto.Facilities;

namespace RCS.WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IDoctorSpecializationService _doctorSpecializationService;

        public DoctorController(IDoctorService doctorService, IDoctorSpecializationService doctorSpecializationService)
        {
            _doctorService = doctorService;
            _doctorSpecializationService = doctorSpecializationService;
        }

        [HttpGet]
        public IActionResult GetDoctorsByTerm(string term)
        {
            var doctors = _doctorService.GetDoctors(term ?? string.Empty);
            return Json(JsonResultData.Success(doctors));
        }

        [HttpGet]
        public IActionResult GetDoctorSpecializationsByTerm(string term)
        {
            var doctors = _doctorSpecializationService.GetDoctorSpecializationByTerm(term ?? string.Empty);
            return Json(JsonResultData.Success(doctors));
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] AddDoctorDto doctorDto)
        {
            _doctorService.AddDoctor(doctorDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult AddDoctorSpecialization([FromBody] AddDoctorSpecializationDto specialization)
        {
            _doctorSpecializationService.AddDoctorSpecialization(specialization);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetDoctors([FromBody] DoctorsFilterParams filterParams)
        {
            var doctors = _doctorService.GetDoctorsByParams(filterParams);
            return Json(JsonResultData.Success(doctors));
        }

        [HttpPost]
        public IActionResult GetDoctorSpecializations([FromBody] DoctorSpecializationsFilterParams filterParams)
        {
            var doctors = _doctorSpecializationService.GetDoctorSpecializationsByParams(filterParams);
            return Json(JsonResultData.Success(doctors));
        }
    }
}