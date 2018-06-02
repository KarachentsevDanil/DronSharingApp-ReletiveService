using RCS.BLL.Dto.Residents;
using System.Collections.Generic;

namespace RCS.WebApi.Models
{
    public class ResidentObservationModel
    {
        public int ResidentId { get; set; }

        public string Date { get; set; }
        
        public List<ObservationDto> Observations { get; set; }
    }
}
