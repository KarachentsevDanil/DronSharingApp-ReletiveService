using System;

namespace RCS.BLL.Dto.Residents
{
    public class AddResidentAnalyzesDto
    {
        public int ResidentId { get; set; }

        public int AnalyzesId { get; set; }

        public int DoctorId { get; set; }

        public DateTime Date { get; set; }
    }
}