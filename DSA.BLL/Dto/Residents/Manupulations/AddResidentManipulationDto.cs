using System;

namespace RCS.BLL.Dto.Residents
{
    public class AddResidentManipulationDto
    {
        public int ResidentId { get; set; }

        public int ManipulationId { get; set; }

        public int DoctorId { get; set; }

        public DateTime Date { get; set; }

        public string Duration { get; set; }
    }
}