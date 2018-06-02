using RCS.BLL.Dto.Residents;

namespace RCS.WebApi.Models
{
    public class ResidentDetailsModel
    {
        public ResidentDto Resident { get; set; }

        public ObservationDto BloodPressure { get; set; }

        public ObservationDto Temperature { get; set; }

        public ObservationDto HeartRate { get; set; }
    }
}
