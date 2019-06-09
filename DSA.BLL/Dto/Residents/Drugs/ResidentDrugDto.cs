using System;

namespace RCS.BLL.Dto.Residents
{
    public class ResidentDrugDto
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int DrugId { get; set; }

        public int DoctorId { get; set; }

        public DateTime OrderDateValue { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int Dosage { get; set; }

        public string Unit { get; set; }

        public string Drug { get; set; }

        public string Doctor { get; set; }
    }
}
