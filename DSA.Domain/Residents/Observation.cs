using System;

namespace RCS.Domain.Residents
{
    public class Observation
    {
        public int ObservationId { get; set; }

        public int ResidentId { get; set; }

        public virtual Resident Resident { get; set; }

        public ObservationType Type { get; set; }

        public double? Value { get; set; }

        public int? DiastolicValue { get; set; }

        public int? SystolicValue { get; set; }

        public string Unit { get; set; }

        public DateTime RecordedDate { get; set; }
    }
    
    public enum ObservationType
    {
        BloodPressure = 1,
        HeartRate = 2,
        Height = 3,
        Weight = 4,
        Temperature = 5
    }
}
