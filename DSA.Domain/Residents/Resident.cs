using RCS.Domain.Facilities;
using System;
using System.Collections.Generic;

namespace RCS.Domain.Residents
{
    public class Resident
    {
        public int ResidentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public DateTime? AdmissionDate { get; set; }

        public DateTime? DischargeDate { get; set; }

        public byte[] Photo { get; set; }

        public int FacilityId { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual ICollection<ResidentContact> Contacts { get; set; }

        public virtual ICollection<ResidentDoctor> Doctors { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual ICollection<Observation> Observations { get; set; }
    }
}
