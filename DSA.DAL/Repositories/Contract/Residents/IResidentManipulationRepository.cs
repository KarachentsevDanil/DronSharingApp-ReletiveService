using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories.Contract
{
    public interface IResidentManipulationRepository : IRepository<ResidentManipulation>
    {
        CollectionResult<ResidentManipulation> GetResidentManipulationsByParams(ResidentManipulationsFilterParams filterParams);
    }
}