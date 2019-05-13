using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class AnalyzesMapping : IMappingContract<Analyzes>
    {
        public void MapEntity(EntityTypeBuilder<Analyzes> builder)
        {
            builder.ToTable("Analyzes", "core");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Department).WithMany(x => x.Analyzes).HasForeignKey(x => x.DepartmentId);
        }
    }
}
