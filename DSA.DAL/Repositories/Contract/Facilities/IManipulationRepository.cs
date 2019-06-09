using System.Collections.Generic;
using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories.Contract
{
    public interface IManipulationRepository : IRepository<Manipulation>
    {
        CollectionResult<Manipulation> GetManipulationsByParams(ManipulationsFilterParams parameters);

        IEnumerable<Manipulation> GetManipulationsByTerm(int facilityId, string term);
    }
}