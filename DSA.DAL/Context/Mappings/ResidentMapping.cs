using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class ResidentMapping : IMappingContract<Resident>
    {
        public void MapEntity(EntityTypeBuilder<Resident> builder)
        {
            builder.ToTable("Residents", "core");

            builder.HasKey(x => x.ResidentId);

            builder.HasOne(x => x.Facility).WithMany(x => x.Residents).HasForeignKey(x => x.FacilityId);
        }
    }
}
