using System;
using RCS.Domain.Facilities;

namespace RCS.Domain.Residents
{
    public class ResidentDrug
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int DrugId { get; set; }

        public int DoctorId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Dosage { get; set; }

        public string Unit { get; set; }

        public Resident Resident { get; set; }

        public Drug Drug { get; set; }

        public Doctor Doctor { get; set; }
    }
}