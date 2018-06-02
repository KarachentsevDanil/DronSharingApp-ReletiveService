using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Facilities;

namespace RCS.DAL.Context.Mappings
{
    public class FacilityMapping : IMappingContract<Facility>
    {
        public void MapEntity(EntityTypeBuilder<Facility> builder)
        {
            builder.ToTable("Facilities", "core");

            builder.HasKey(x => x.FacilityId);
        }
    }
}
