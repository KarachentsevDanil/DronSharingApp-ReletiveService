using RCS.Domain.Residents;

namespace RCS.Domain.Params
{
    public class ResidentManipulationsFilterParams : FilterParams<ResidentManipulation>
    {
        public int ResidentId { get; set; }
    }
}
