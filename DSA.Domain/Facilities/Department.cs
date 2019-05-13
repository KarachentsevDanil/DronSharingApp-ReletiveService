using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.Domain.Facilities
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int FacilityId { get; set; }

        public Facility Facility { get; set; }

        public virtual ICollection<Resident> Residents { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

        public virtual ICollection<Analyzes> Analyzes { get; set; }

        public virtual ICollection<Manipulation> Manipulations { get; set; }
    }
}