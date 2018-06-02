using RCS.DAL.Context.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RCS.Domain.Users;
using RCS.Domain.Facilities;
using RCS.Domain.Residents;

namespace RCS.DAL.Context
{
    public class RelativeCommunicationContext : IdentityDbContext<User>
    {
        public RelativeCommunicationContext(DbContextOptions<RelativeCommunicationContext> options) : base(options)
        { }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<Observation> Observations { get; set; }

        public DbSet<Resident> Residents { get; set; }

        public DbSet<ResidentContact> ResidentContacts { get; set; }

        public DbSet<ResidentDoctor> ResidentDoctors { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new AppointmentMapping().MapEntity(builder.Entity<Appointment>());
            new DoctorMapping().MapEntity(builder.Entity<Doctor>());
            new DoctorSpecializationMapping().MapEntity(builder.Entity<DoctorSpecialization>());
            new FacilityMapping().MapEntity(builder.Entity<Facility>());
            new ObservationMapping().MapEntity(builder.Entity<Observation>());
            new ResidentContactMapping().MapEntity(builder.Entity<ResidentContact>());
            new ResidentMapping().MapEntity(builder.Entity<Resident>());
            new ResidentDoctorMapping().MapEntity(builder.Entity<ResidentDoctor>());
            new UserMapping().MapEntity(builder.Entity<User>());
        }
    }
}
