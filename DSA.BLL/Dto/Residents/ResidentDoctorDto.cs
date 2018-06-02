namespace RCS.BLL.Dto.Residents
{
    public class ResidentDoctorDto
    {
        public int ResidentDoctorId { get; set; }

        public int ResidentId { get; set; }

        public int DoctorId { get; set; }

        public string ResidentName { get; set; }

        public string DoctorName { get; set; }
    }
}
