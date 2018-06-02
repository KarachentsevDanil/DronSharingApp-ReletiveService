using RCS.BLL.Dto.Residents;
using RCS.IoT.Extenction;

namespace RCS.IoT.Service
{
    public class ObservationService
    {
        private const string _baseObservationDto = "/api/observation/";
        private const string _addObservation = "addObservation";

        public static void AddObservation(AddObservationDto observationDto)
        {
            HttpClientExtenction.PostData(observationDto, string.Concat(_baseObservationDto, _addObservation));
        }
    }
}
