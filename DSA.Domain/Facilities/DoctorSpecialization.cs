using System.Collections.Generic;

namespace RCS.Domain.Facilities
{
    public class DoctorSpecialization
    {
        public int DoctorSpecializationId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
