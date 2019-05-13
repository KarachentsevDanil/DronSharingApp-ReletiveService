using RCS.Domain.Facilities;
using System;

namespace RCS.Domain.Residents
{
    public class ResidentManipulation
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int ManipulationId { get; set; }

        public int DoctorId { get; set; }

        public DateTime Date { get; set; }

        public string Duration { get; set; }

        public Resident Resident { get; set; }

        public Manipulation Manipulation { get; set; }

        public Doctor Doctor { get; set; }
    }
}