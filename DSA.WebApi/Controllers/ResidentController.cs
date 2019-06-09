using System.Collections.Generic;
using RCS.BLL.Services.Contracts;
using RCS.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;
using System.Linq;
using RCS.BLL.Services.Contracts.Residents;
using RCS.WebApi.Extensions;

namespace RCS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ResidentController : Controller
    {
        private readonly IResidentService _residentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IResidentContactService _residentContactService;
        private readonly IResidentDoctorService _residentDoctorService;
        private readonly IResidentAnalyzesService _residentAnalyzesService;
        private readonly IResidentDrugService _residentDrugService;
        private readonly IResidentManipulationService _residentManipulationService;
        private readonly IObservationService _observationService;

        public ResidentController(
            IResidentService residentService,
            IResidentContactService residentContactService,
            IAppointmentService appointmentService,
            IResidentDoctorService residentDoctorService,
            IObservationService observationService,
            IResidentAnalyzesService residentAnalyzesService,
            IResidentDrugService residentDrugService,
            IResidentManipulationService residentManipulationService)
        {
            _residentService = residentService;
            _residentContactService = residentContactService;
            _appointmentService = appointmentService;
            _residentDoctorService = residentDoctorService;
            _observationService = observationService;
            _residentAnalyzesService = residentAnalyzesService;
            _residentDrugService = residentDrugService;
            _residentManipulationService = residentManipulationService;
        }

        [HttpPost]
        public IActionResult AddResident([FromBody] AddResidentDto residentDto)
        {
            _residentService.AddResident(residentDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult AddResidentDoctor([FromBody] AddResidentDoctorDto residentDoctorDto)
        {
            _residentDoctorService.AddResidentDoctor(residentDoctorDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult AddResidentContact([FromBody] AddResidentContactDto residentContactDto)
        {
            _residentContactService.AddResidentContact(residentContactDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult AddResidentAnalyzes([FromBody] AddResidentAnalyzesDto data)
        {
            var userModel = User.GetUserModel();
            data.DoctorId = userModel.DoctorId.Value;

            _residentAnalyzesService.AddResidentAnalyzes(data);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult AddResidentDrug([FromBody] AddResidentDrugDto data)
        {
            var userModel = User.GetUserModel();
            data.DoctorId = userModel.DoctorId.Value;

            _residentDrugService.AddResidentDrug(data);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult AddResidentManipulation([FromBody] AddResidentManipulationDto data)
        {
            var userModel = User.GetUserModel();
            data.DoctorId = userModel.DoctorId.Value;

            _residentManipulationService.AddResidentManipulation(data);
            return Json(JsonResultData.Success());
        }

        [HttpGet]
        public IActionResult GetResidentById(int id)
        {
            var resident = _residentService.GetResidentById(id);

            var residentObservations = _observationService.GetObservationsByParams(new ObservationParams
            {
                ResidentId = id
            });

            var residentModel = new ResidentDetailsModel
            {
                Resident = resident,
                BloodPressure = residentObservations.Collection.FirstOrDefault(t => t.Type == Domain.Residents.ObservationType.BloodPressure),
                HeartRate = residentObservations.Collection.FirstOrDefault(t => t.Type == Domain.Residents.ObservationType.HeartRate),
                Temperature = residentObservations.Collection.FirstOrDefault(t => t.Type == Domain.Residents.ObservationType.Temperature)
            };

            return Json(JsonResultData.Success(residentModel));
        }

        [HttpGet]
        public IActionResult GetResidentsByTerm(string term)
        {
            var residents = _residentService.GetResidentsByTerm(term ?? string.Empty);
            return Json(JsonResultData.Success(residents));
        }

        [HttpPost]
        public IActionResult GetResidents([FromBody] ResidentsFilterParams filterParams)
        {
            var userModel = User.GetUserModel();

            filterParams.FacilityId = userModel.FacilityId;
            filterParams.DoctorId = userModel.DoctorId;

            var residents = _residentService.GetResidentsByParams(filterParams);
            return Json(JsonResultData.Success(residents));
        }

        [HttpPost]
        public IActionResult GetResidentDrugs([FromBody] ResidentDrugsFilterParams filterParams)
        {
            var items = _residentDrugService.GetResidentDrugsByParams(filterParams);
            return Json(JsonResultData.Success(items));
        }

        [HttpPost]
        public IActionResult GetResidentAnalyzes([FromBody] ResidentAnalyzesFilterParams filterParams)
        {
            var items = _residentAnalyzesService.GetResidentAnalyzesByParams(filterParams);
            return Json(JsonResultData.Success(items));
        }

        [HttpPost]
        public IActionResult GetResidentManipulations([FromBody] ResidentManipulationsFilterParams filterParams)
        {
            var items = _residentManipulationService.GetResidentManipulationsByParams(filterParams);
            return Json(JsonResultData.Success(items));
        }

        [HttpPost]
        public IActionResult GetResidentsForIoT([FromBody] ResidentsFilterParams filterParams)
        {
            var residents = _residentService.GetResidentsByParams(filterParams);
            return Json(residents);
        }

        [HttpPost]
        public IActionResult GetResidentContacts([FromBody] ResidentContactsFilterParams filterParams)
        {
            var residents = _residentContactService.GetResidentContactsByParams(filterParams);
            return Json(JsonResultData.Success(residents));
        }

        [HttpPost]
        public IActionResult UpdateResidentContact([FromBody] ResidentContactDto resident)
        {
            _residentContactService.UpdateResidentContact(resident);
            return Json(JsonResultData.Success());
        }

        [HttpGet]
        public IActionResult GetResidentTimeline(int residentId)
        {
            List<TimelineDto> timelines = new List<TimelineDto>();

            var analyzes = _residentAnalyzesService.GetResidentAnalyzesByParams(new ResidentAnalyzesFilterParams()
            {
                ResidentId = residentId,
                Skip = 0,
                Take = int.MaxValue
            });

            var drugs = _residentDrugService.GetResidentDrugsByParams(new ResidentDrugsFilterParams()
            {
                ResidentId = residentId,
                Skip = 0,
                Take = int.MaxValue
            });

            var manipulations = _residentManipulationService.GetResidentManipulationsByParams(new ResidentManipulationsFilterParams()
            {
                ResidentId = residentId,
                Skip = 0,
                Take = int.MaxValue
            });

            var visits = _appointmentService.GetAppointmentsByParams(new AppointmentsFilterParams()
            {
                ResidentId = residentId,
                Skip = 0,
                Take = int.MaxValue
            });

            timelines.AddRange(analyzes.Collection.Select(t => new TimelineDto()
            {
                EventDate = t.OrderDateValue,
                Item = t,
                Type = (int)TimelineType.Analyze
            }));

            timelines.AddRange(drugs.Collection.Select(t => new TimelineDto()
            {
                EventDate = t.OrderDateValue,
                Item = t,
                Type = (int)TimelineType.Drug
            }));

            timelines.AddRange(manipulations.Collection.Select(t => new TimelineDto()
            {
                EventDate = t.OrderDateValue,
                Item = t,
                Type = (int)TimelineType.Manipulation
            }));

            timelines.AddRange(visits.Collection.Select(t => new TimelineDto()
            {
                EventDate = t.Date,
                Item = t,
                Type = (int)TimelineType.Appointment
            }));

            return Json(JsonResultData.Success(timelines.OrderByDescending(t => t.EventDate)));
        }
    }
}