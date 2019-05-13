using RCS.Domain.Residents;

namespace RCS.Domain.Params
{
    public class ResidentAnalyzesFilterParams : FilterParams<ResidentAnalyzes>
    {
        public int ResidentId { get; set; }
    }
}