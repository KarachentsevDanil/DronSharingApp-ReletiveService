using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories.Contract
{
    public interface IResidentAnalyzesRepository : IRepository<ResidentAnalyzes>
    {
        CollectionResult<ResidentAnalyzes> GetResidentAnalyzesByParams(ResidentAnalyzesFilterParams filterParams);
    }
}
