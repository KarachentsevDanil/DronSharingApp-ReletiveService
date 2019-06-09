using RCS.BLL.Dto.Facilities;
using RCS.Domain.Params;
using System.Collections.Generic;

namespace RCS.BLL.Services.Contracts
{
    public interface IDrugService
    {
        void AddDrug(AddDrugDto data);
        
        CollectionResult<DrugDto> GetDrugsByParams(DrugsFilterParams filterParams);

        IEnumerable<DrugDto> GetDrugsByTerm(string term);
    }
}