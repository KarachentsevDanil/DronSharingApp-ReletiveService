using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class ResidentAnalyzesMapping : IMappingContract<ResidentAnalyzes>
    {
        public void MapEntity(EntityTypeBuilder<ResidentAnalyzes> builder)
        {
            builder.ToTable("ResidentAnalyzes", "core");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Resident)
                .WithMany(x => x.Analyzes)
                .HasForeignKey(x => x.ResidentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Analyzes)
                .WithMany(x => x.ResidentAnalyzes)
                .HasForeignKey(x => x.AnalyzesId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.ResidentAnalyzes)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
