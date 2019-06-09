using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RCS.BLL.Dto.Facilities;
using RCS.BLL.Services.Contracts;
using RCS.Domain.Params;
using RCS.Domain.Users;
using RCS.WebApi.Extensions;
using RCS.WebApi.Models;

namespace RCS.WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DoctorController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IDoctorService _doctorService;
        private readonly IDoctorSpecializationService _doctorSpecializationService;

        public DoctorController(
            IDoctorService doctorService,
            IDoctorSpecializationService doctorSpecializationService,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _doctorService = doctorService;
            _doctorSpecializationService = doctorSpecializationService;
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> AddDoctor([FromBody] AddDoctorDto doctorDto)
        {
            int doctorId = _doctorService.AddDoctor(doctorDto);

            var user = new User
            {
                UserName = doctorDto.Email,
                Email = doctorDto.Email,
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName,
                FacilityId = doctorDto.FacilityId,
                DoctorId = doctorId,
                Role = Role.FacilityDoctor
            };

            var result = await _userManager.CreateAsync(user, doctorDto.Password);

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
            var userModel = User.GetUserModel();

            if (userModel.FacilityId.HasValue)
            {
                filterParams.FacilityId = userModel.FacilityId.Value;
            }

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