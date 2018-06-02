using RCS.Domain.Residents;

namespace RCS.Domain.Params
{
    public class ResidentContactsFilterParams : FilterParams<ResidentContact>
    {
        public string UserId { get; set; }

        public int? FacilityId { get; set; }
    }
}
