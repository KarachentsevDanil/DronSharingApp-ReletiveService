using RCS.Domain.Residents;

namespace RCS.Domain.Params
{
    public class DrugsFilterParams : FilterParams<Drug>
    {
        public string Term { get; set; }
    }
}
