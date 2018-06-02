using RCS.Domain.Residents;
using System;

namespace RCS.BLL.Dto.Residents
{
    public class ObservationDto
    {
        public int ObservationId { get; set; }

        public int ResidentId { get; set; }

        public string ResidentName { get; set; }

        public ObservationType Type { get; set; }

        public ObservationType TypeValue { get; set; }

        public double? Value { get; set; }

        public int? DiastolicValue { get; set; }

        public int? SystolicValue { get; set; }

        public string OutputValue { get; set; }

        public string Unit { get; set; }

        public string RecordedDate { get; set; }
    }
}
