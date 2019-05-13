using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;
using System.Collections.Generic;

namespace RCS.BLL.Services.Contracts
{
    public interface IResidentService
    {
        ResidentDto GetResidentById(int id);

        void AddResident(AddResidentDto data);
        
        CollectionResult<ResidentDto> GetResidentsByParams(ResidentsFilterParams filterParams);

        IEnumerable<ResidentDto> GetResidentsByTerm(string term);
    }
}
