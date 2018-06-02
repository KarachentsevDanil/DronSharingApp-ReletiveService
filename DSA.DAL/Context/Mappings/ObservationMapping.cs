using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class ObservationMapping : IMappingContract<Observation>
    {
        public void MapEntity(EntityTypeBuilder<Observation> builder)
        {
            builder.ToTable("Observations", "core");

            builder.HasKey(x => x.ObservationId);

            builder.HasOne(x => x.Resident).WithMany(x => x.Observations).HasForeignKey(x => x.ResidentId);
        }
    }
}
