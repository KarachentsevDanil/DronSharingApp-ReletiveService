using RCS.Domain.Residents;
using RCS.Domain.Users;
using System;
using System.Collections.Generic;

namespace RCS.Domain.Facilities
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public byte[] Photo { get; set; }

        public DateTime? BirthDate { get; set; }

        public int DepartmentId { get; set; }

        public string UserId { get; set; }

        public int DoctorSpecializationId { get; set; }

        public virtual Department Department { get; set; }

        public virtual User User { get; set; }

        public virtual DoctorSpecialization DoctorSpecialization { get; set; }

        public virtual ICollection<ResidentDoctor> Residents { get; set; }

        public virtual ICollection<ResidentDrug> Drugs { get; set; }

        public virtual ICollection<ResidentManipulation> ResidentManipulations { get; set; }

        public virtual ICollection<ResidentAnalyzes> ResidentAnalyzes { get; set; }
    }
}