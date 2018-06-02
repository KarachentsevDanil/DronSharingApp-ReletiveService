using RCS.Domain.Facilities;

namespace RCS.Domain.Params
{
    public class DoctorSpecializationsFilterParams : FilterParams<DoctorSpecialization>
    {
        public string Term { get; set; }

        public int? FacilityId { get; set; }
    }
}
