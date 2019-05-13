using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class ResidentManipulationMapping : IMappingContract<ResidentManipulation>
    {
        public void MapEntity(EntityTypeBuilder<ResidentManipulation> builder)
        {
            builder.ToTable("ResidentManipulations", "core");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Resident).WithMany(x => x.Manipulations).HasForeignKey(x => x.ResidentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Manipulation).WithMany(x => x.ResidentManipulations).HasForeignKey(x => x.ManipulationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Doctor).WithMany(x => x.ResidentManipulations).HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
