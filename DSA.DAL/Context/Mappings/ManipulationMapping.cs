using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class ManipulationMapping : IMappingContract<Manipulation>
    {
        public void MapEntity(EntityTypeBuilder<Manipulation> builder)
        {
            builder.ToTable("Manipulations", "core");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Department).WithMany(x => x.Manipulations).HasForeignKey(x => x.DepartmentId);
        }
    }
}
