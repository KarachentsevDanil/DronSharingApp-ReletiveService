using System;
using RCS.Domain.Facilities;

namespace RCS.Domain.Residents
{
    public class ResidentAnalyzes
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int AnalyzesId { get; set; }

        public int DoctorId { get; set; }

        public DateTime Date { get; set; }

        public byte[] AnalyzeResult { get; set; }

        public string FileType { get; set; }

        public Resident Resident { get; set; }

        public Analyzes Analyzes { get; set; }

        public Doctor Doctor { get; set; }
    }
}