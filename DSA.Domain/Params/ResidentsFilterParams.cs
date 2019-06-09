using RCS.Domain.Residents;

namespace RCS.Domain.Params
{
    public class ResidentsFilterParams : FilterParams<Resident>
    {
        public string Term { get; set; }

        public int? FacilityId { get; set; }

        public int? DoctorId { get; set; }
    }
}
