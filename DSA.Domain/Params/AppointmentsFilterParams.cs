using RCS.Domain.Residents;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCS.Domain.Params
{
    public class AppointmentsFilterParams : FilterParams<Appointment>
    {
        public int ResidentId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
