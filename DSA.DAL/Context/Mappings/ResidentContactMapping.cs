using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class ResidentContactMapping : IMappingContract<ResidentContact>
    {
        public void MapEntity(EntityTypeBuilder<ResidentContact> builder)
        {
            builder.ToTable("ResidentContacts", "core");

            builder.HasKey(x => x.ResidentContactId);

            builder.HasOne(x => x.Resident).WithMany(x => x.Contacts).HasForeignKey(x => x.ResidentId);

            builder.HasOne(x => x.User).WithMany(x => x.Residents).HasForeignKey(x => x.UserId);
        }
    }
}
