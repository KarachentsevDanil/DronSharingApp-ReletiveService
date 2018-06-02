using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Facilities;

namespace RCS.DAL.Context.Mappings
{
    public class DoctorMapping : IMappingContract<Doctor>
    {
        public void MapEntity(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors", "core");

            builder.HasKey(x => x.DoctorId);

            builder.HasOne(x => x.DoctorSpecialization).WithMany(x => x.Doctors).HasForeignKey(x => x.DoctorSpecializationId);

            builder.HasOne(x => x.Facility).WithMany(x => x.Doctors).HasForeignKey(x => x.FacilityId);
        }
    }
}
