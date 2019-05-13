using System;

namespace RCS.BLL.Dto.Residents
{
    public class ResidentManipulationDto
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int ManipulationId { get; set; }

        public int DoctorId { get; set; }

        public string Date { get; set; }

        public string Duration { get; set; }

        public string Manipulation { get; set; }

        public string Doctor { get; set; }

        public string Department { get; set; }

        public string RoomNumber { get; set; }
    }
}
