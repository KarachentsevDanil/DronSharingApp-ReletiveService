using RCS.Domain.Residents;
using System;

namespace RCS.Domain.Params
{
    public class ObservationParams : FilterParams<Observation>
    {
        public int ResidentId { get; set; }

        public ObservationType? Type { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
