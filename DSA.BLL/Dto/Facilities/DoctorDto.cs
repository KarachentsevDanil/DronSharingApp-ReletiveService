namespace RCS.BLL.Dto.Facilities
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }

        public string FullName { get; set; }

        public int FacilityId { get; set; }

        public int DoctorSpecializationId { get; set; }

        public string FacilityName { get; set; }

        public string Specialization { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Photo { get; set; }

        public string BirthDate { get; set; }
    }
}
