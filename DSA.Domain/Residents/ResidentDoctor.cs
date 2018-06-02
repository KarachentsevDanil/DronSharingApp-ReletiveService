using RCS.Domain.Facilities;

namespace RCS.Domain.Residents
{
    public class ResidentDoctor
    {
        public int ResidentDoctorId { get; set; }

        public int ResidentId { get; set; }

        public int DoctorId { get; set; }

        public virtual Resident Resident { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
