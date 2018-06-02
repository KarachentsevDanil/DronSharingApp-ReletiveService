using RCS.Domain.Facilities;

namespace RCS.Domain.Params
{
    public class FacilitiesFilterParams : FilterParams<Facility>
    {
        public string Term { get; set; }
    }
}
