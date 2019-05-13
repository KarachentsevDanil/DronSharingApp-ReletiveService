using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories.Contract
{
    public interface IDrugRepository : IRepository<Drug>
    {
        CollectionResult<Drug> GetDrugsByParams(DrugsFilterParams parameters);
    }
}