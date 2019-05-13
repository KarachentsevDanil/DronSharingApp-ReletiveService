using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Facilities;

namespace RCS.DAL.Context.Mappings
{
    public class DepartmentMapping : IMappingContract<Department>
    {
        public void MapEntity(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments", "core");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Facility).WithMany(x => x.Departments).HasForeignKey(x => x.FacilityId);
        }
    }
}
