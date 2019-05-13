using RCS.Domain.Residents;

namespace RCS.Domain.Params
{
    public class ManipulationsFilterParams : FilterParams<Manipulation>
    {
        public int DepartmentId { get; set; }

        public string Term { get; set; }
    }
}