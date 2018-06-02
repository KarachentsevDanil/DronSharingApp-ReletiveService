namespace RCS.BLL.Dto.Facilities
{
    public class AddDoctorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int FacilityId { get; set; }

        public int DoctorSpecializationId { get; set; }
    }
}
