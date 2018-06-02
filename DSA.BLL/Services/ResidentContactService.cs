using RCS.BLL.Dto.Residents;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.BLL.Services
{
    public class ResidentContactService : IResidentContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResidentContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddResidentContact(AddResidentContactDto data)
        {
            var newItem = AutoMapper.Mapper.Map<AddResidentContactDto, ResidentContact>(data);
            _unitOfWork.ResidentContactRepository.Add(newItem);
            _unitOfWork.Commit();
        }

        public CollectionResult<ResidentContactDto> GetResidentContactsByParams(ResidentContactsFilterParams filterParams)
        {
            var residents = _unitOfWork.ResidentContactRepository.GetResidentContactsByParams(filterParams);

            var result = new CollectionResult<ResidentContactDto>
            {
                TotalCount = residents.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<ResidentContact>, List<ResidentContactDto>>(residents.Collection)
            };

            return result;
        }

        public void UpdateResidentContact(ResidentContactDto data)
        {
            var newItem = AutoMapper.Mapper.Map<ResidentContactDto, ResidentContact>(data);
            _unitOfWork.ResidentContactRepository.Update(newItem);
            _unitOfWork.Commit();
        }
    }
}
