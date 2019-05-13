using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IResidentDrugService
    {
        void AddResidentDrug(AddResidentDrugDto data);

        CollectionResult<ResidentDrugDto> GetResidentDrugsByParams(ResidentDrugsFilterParams filterParams);
    }
}