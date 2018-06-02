using System;
using System.Collections.Generic;
using System.Text;

namespace RCS.BLL.Dto.Residents
{
    public class AddResidentDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public DateTime? AdmissionDate { get; set; }

        public DateTime? DischargeDate { get; set; }

        public string Photo { get; set; }

        public int FacilityId { get; set; }
    }
}
