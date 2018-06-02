using System.Collections.Generic;
using RCS.BLL.Dto.Residents;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.BLL.Services
{
    public class ResidentService : IResidentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResidentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddResident(AddResidentDto data)
        {
            var newItem = AutoMapper.Mapper.Map<AddResidentDto, Resident>(data);
            _unitOfWork.ResidentRepository.Add(newItem);
            _unitOfWork.Commit();
        }

        public ResidentDto GetResidentById(int id)
        {
            var resident = _unitOfWork.ResidentRepository.GetResidentById(id);
            return AutoMapper.Mapper.Map<Resident, ResidentDto>(resident);
        }

        public IEnumerable<ResidentDto> GetResidentsByTerm(string term)
        {
            var residents = _unitOfWork.ResidentRepository.GetResidents(term);
            return AutoMapper.Mapper.Map<IEnumerable<Resident>, IEnumerable<ResidentDto>>(residents);
        }

        public CollectionResult<ResidentDto> GetResidentsByParams(ResidentsFilterParams filterParams)
        {
            var residents = _unitOfWork.ResidentRepository.GetResidentsByParams(filterParams);

            var result = new CollectionResult<ResidentDto>
            {
                TotalCount = residents.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Resident>, List<ResidentDto>>(residents.Collection)
            };

            return result;
        }
    }
}
