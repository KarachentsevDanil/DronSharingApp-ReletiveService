using RCS.Domain.Users;

namespace RCS.Domain.Params
{
    public class UsersFilterParams : FilterParams<User>
    {
        public string Term { get; set; }

        public int? FacilityId { get; set; }

        public bool OnlyWithFacility { get; set; }
    }
}
