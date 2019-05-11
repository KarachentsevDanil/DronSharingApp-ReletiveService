using RCS.BLL.Services.Contracts;
using RCS.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;
using System.Linq;

namespace RCS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ObservationController : Controller
    {
        private readonly IObservationService _observationService;

        public ObservationController(IObservationService observationService)
        {
            _observationService = observationService;
        }

        [HttpPost]
        public IActionResult AddObservation([FromBody] AddObservationDto observationDto)
        {
            _observationService.AddObservation(observationDto);
            return Json(JsonResultData.Success());
        }

        [HttpPost]
        public IActionResult GetObservationsByParams([FromBody] ObservationParams filterParams)
        {
            var observations = _observationService.GetObservationsByParams(filterParams);
            return Json(JsonResultData.Success(observations));
        }

        [HttpPost]
        public IActionResult GetObservation([FromBody] GetObservationsModel model)
        {
            var filterParams = new ObservationParams
            {
                ResidentId = model.ResidentId,
                Type = model.Type,
                Take = model.Take
            };

            var observations = _observationService.GetObservationsByParams(filterParams);
            var firstObservation = observations.Collection.FirstOrDefault();

            var residentObservations = new ResidentObservationModel
            {
                ResidentId = model.ResidentId,
                Date = firstObservation?.RecordedDate,
                Observations = observations.Collection.ToList()
            };

            return Ok(residentObservations);
        }
    }
}