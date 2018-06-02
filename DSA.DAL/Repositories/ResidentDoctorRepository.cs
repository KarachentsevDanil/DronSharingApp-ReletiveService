using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories
{
    public class ResidentDoctorRepository : Repository<ResidentDoctor>, IResidentDoctorRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public ResidentDoctorRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
