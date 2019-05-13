using System.Collections.Generic;
using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IResidentContactService
    {
        void AddResidentContact(AddResidentContactDto data);

        void UpdateResidentContact(ResidentContactDto data);

        CollectionResult<ResidentContactDto> GetResidentContactsByParams(ResidentContactsFilterParams filterParams);
    }
}
