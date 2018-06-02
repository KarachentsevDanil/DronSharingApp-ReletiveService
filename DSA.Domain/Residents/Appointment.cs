using RCS.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCS.Domain.Residents
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public int ResidentId { get; set; }

        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Duration { get; set; }

        public virtual Resident Resident { get; set; }

        public virtual User User { get; set; }
    }
}
