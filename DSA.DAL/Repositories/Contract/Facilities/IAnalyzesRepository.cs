using System.Collections.Generic;
using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories.Contract
{
    public interface IAnalyzesRepository : IRepository<Analyzes>
    {
        CollectionResult<Analyzes> GetAnalyzesByParams(AnalyzesFilterParams parameters);

        IEnumerable<Analyzes> GetAnalyzesByTerm(int facilityId, string term);
    }
}