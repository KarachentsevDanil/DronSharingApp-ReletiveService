using RCS.Domain.Facilities;

namespace RCS.Domain.Params
{
    public class DoctorsFilterParams : FilterParams<Doctor>
    {
        public string Term { get; set; }

        public int? FacilityId { get; set; }

        public int? ResidentId { get; set; }
    }
}
