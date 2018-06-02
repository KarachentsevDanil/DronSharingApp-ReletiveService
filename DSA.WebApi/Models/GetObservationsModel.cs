using RCS.Domain.Residents;

namespace RCS.WebApi.Models
{
    public class GetObservationsModel
    {
        public int ResidentId { get; set; }

        public ObservationType Type { get; set; }

        public int Take { get; set; }
    }
}
