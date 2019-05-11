using System;

namespace RCS.BLL.Dto.Facilities
{
    public class AddDoctorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int FacilityId { get; set; }

        public int DoctorSpecializationId { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Photo { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
