using RCS.Domain.Facilities;

namespace RCS.Domain.Params
{
    public class DepartmentsFilterParams : FilterParams<Department>
    {
        public int FacilityId { get; set; }

        public string Term { get; set; }
    }
}
