using System;

namespace RCS.BLL.Dto.Residents
{
    public class ResidentAnalyzesDto
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int AnalyzesId { get; set; }

        public int DoctorId { get; set; }

        public string Date { get; set; }

        public DateTime OrderDateValue { get; set; }

        public string AnalyzeResult { get; set; }

        public string Analyzes { get; set; }

        public string Doctor { get; set; }

        public string Department { get; set; }

        public string RoomNumber { get; set; }
    }
}
