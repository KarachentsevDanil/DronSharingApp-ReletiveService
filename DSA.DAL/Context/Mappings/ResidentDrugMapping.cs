using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class ResidentDrugMapping : IMappingContract<ResidentDrug>
    {
        public void MapEntity(EntityTypeBuilder<ResidentDrug> builder)
        {
            builder.ToTable("ResidentDrugs", "core");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Resident).WithMany(x => x.Drugs).HasForeignKey(x => x.ResidentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Drug).WithMany(x => x.ResidentMedications).HasForeignKey(x => x.DrugId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Doctor).WithMany(x => x.Drugs).HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
