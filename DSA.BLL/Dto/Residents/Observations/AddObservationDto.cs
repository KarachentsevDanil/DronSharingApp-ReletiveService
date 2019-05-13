using RCS.Domain.Residents;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCS.BLL.Dto.Residents
{
    public class AddObservationDto
    {
        public int ResidentId { get; set; }
        
        public ObservationType Type { get; set; }

        public double? Value { get; set; }

        public int? DiastolicValue { get; set; }

        public int? SystolicValue { get; set; }

        public string Unit { get; set; }

        public DateTime RecordedDate { get; set; }
    }
}
