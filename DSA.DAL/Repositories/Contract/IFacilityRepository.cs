using RCS.Domain.Facilities;
using RCS.Domain.Params;
using System.Collections.Generic;

namespace RCS.DAL.Repositories.Contract
{
    public interface IFacilityRepository : IRepository<Facility>
    {
        CollectionResult<Facility> GetFacilitiesByParams(FacilitiesFilterParams filterParams);

        IEnumerable<Facility> GetFacilitiesByTerm(string term);
    }
}
