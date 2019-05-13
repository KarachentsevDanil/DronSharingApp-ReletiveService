using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories.Contract
{
    public interface IResidentContactRepository : IRepository<ResidentContact>
    {
        CollectionResult<ResidentContact> GetResidentContactsByParams(ResidentContactsFilterParams filterParams);
    }
}
