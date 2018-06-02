using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class AppointmentMapping : IMappingContract<Appointment>
    {
        public void MapEntity(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments", "core");

            builder.HasKey(x => x.AppointmentId);

            builder.HasOne(x => x.Resident).WithMany(x => x.Appointments).HasForeignKey(x => x.ResidentId);

            builder.HasOne(x => x.User).WithMany(x => x.Appointments).HasForeignKey(x => x.UserId);
        }
    }
}
