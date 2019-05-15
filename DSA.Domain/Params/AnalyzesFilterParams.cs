using RCS.Domain.Residents;

namespace RCS.Domain.Params
{
    public class AnalyzesFilterParams : FilterParams<Analyzes>
    {
        public int FacilityId { get; set; }

        public string Term { get; set; }
    }
}
