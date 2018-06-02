using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Facilities;

namespace RCS.DAL.Context.Mappings
{
    public class DoctorSpecializationMapping : IMappingContract<DoctorSpecialization>
    {
        public void MapEntity(EntityTypeBuilder<DoctorSpecialization> builder)
        {
            builder.ToTable("DoctorSpecializations", "core");

            builder.HasKey(x => x.DoctorSpecializationId);
        }
    }
}
