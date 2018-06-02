using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Users;

namespace RCS.DAL.Context.Mappings
{
    public class UserMapping : IMappingContract<User>
    {
        public void MapEntity(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "core");

            builder.HasOne(x => x.Facility).WithMany(x => x.Users).HasForeignKey(x => x.FacilityId);
        }
    }
}
