using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.DAL.Repositories.Contract
{
    public interface IDrugRepository : IRepository<Drug>
    {
        CollectionResult<Drug> GetDrugsByParams(DrugsFilterParams parameters);

        IEnumerable<Drug> GetDrugsByTerm(string term);
    }
}