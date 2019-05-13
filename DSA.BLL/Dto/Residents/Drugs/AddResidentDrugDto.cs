using System;

namespace RCS.BLL.Dto.Residents
{
    public class AddResidentDrugDto
    {
        public int ResidentId { get; set; }

        public int DrugId { get; set; }

        public int DoctorId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Dosage { get; set; }

        public string Unit { get; set; }
    }
}