using System.Collections.Generic;
using RCS.BLL.Dto.Facilities;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IAnalyzesService
    {
        void AddAnalyzes(AddAnalyzesDto data);
        
        CollectionResult<AnalyzesDto> GetAnalyzesByParams(AnalyzesFilterParams filterParams);

        IEnumerable<AnalyzesDto> GetAnalyzesByTerm(int facilityId, string term);
    }
}