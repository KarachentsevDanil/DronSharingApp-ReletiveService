using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class DrugMapping : IMappingContract<Drug>
    {
        public void MapEntity(EntityTypeBuilder<Drug> builder)
        {
            builder.ToTable("Drugs", "core");

            builder.HasKey(x => x.Id);
        }
    }
}
