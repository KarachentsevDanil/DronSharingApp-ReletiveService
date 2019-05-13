using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories.Contract
{
    public interface IResidentDrugRepository : IRepository<ResidentDrug>
    {
        CollectionResult<ResidentDrug> GetResidentDrugsByParams(ResidentDrugsFilterParams filterParams);
    }
}