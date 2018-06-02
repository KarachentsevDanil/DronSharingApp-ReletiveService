using RCS.BLL.Dto.Facilities;
using RCS.Domain.Params;
using System.Collections.Generic;

namespace RCS.BLL.Services.Contracts
{
    public interface IFacilityService
    {
        void AddFacility(AddFacilityDto data);

        CollectionResult<FacilityDto> GetFacilitiesByParams(FacilitiesFilterParams filterParams);

        IEnumerable<FacilityDto> GetFacilitiesByTerm(string term);
    }
}
