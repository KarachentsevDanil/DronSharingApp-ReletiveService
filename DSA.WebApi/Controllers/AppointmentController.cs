using RCS.BLL.Services.Contracts;
using RCS.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCS.Domain.Params;
using RCS.BLL.Dto.Residents;

namespace RCS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public IActionResult AddAppointment([FromBody]AddAppointmentDto appointment)
        {
            _appointmentService.AddAppointment(appointment);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetAppointments([FromBody] AppointmentsFilterParams filterParams)
        {
            var appointments = _appointmentService.GetAppointmentsByParams(filterParams);
            return Json(JsonResultData.Success(appointments));
        }
    }
}
