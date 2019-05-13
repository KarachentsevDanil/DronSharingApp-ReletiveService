using RCS.Domain.Residents;

namespace RCS.Domain.Params
{
    public class ResidentDrugsFilterParams : FilterParams<ResidentDrug>
    {
        public int ResidentId { get; set; }
    }
}
