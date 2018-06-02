using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.DAL.Repositories.Contract
{
    public interface IResidentRepository : IRepository<Resident>
    {
        CollectionResult<Resident> GetResidentsByParams(ResidentsFilterParams filterParams);

        IEnumerable<Resident> GetResidents(string term);

        Resident GetResidentById(int residentId);
    }
}
