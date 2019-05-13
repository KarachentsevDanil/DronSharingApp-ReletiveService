using System.Collections.Generic;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.BLL.Dto.Facilities;
using RCS.Domain.Facilities;

namespace RCS.BLL.Services
{
    public class DoctorSpecializationService : IDoctorSpecializationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorSpecializationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddDoctorSpecialization(AddDoctorSpecializationDto data)
        {
            var specialization = AutoMapper.Mapper.Map<AddDoctorSpecializationDto, DoctorSpecialization>(data);
            _unitOfWork.DoctorSpecializationRepository.Add(specialization);
            _unitOfWork.Commit();
        }
        
        public IEnumerable<DoctorSpecializationDto> GetDoctorSpecializationByTerm(string term)
        {
            var specializations = _unitOfWork.DoctorSpecializationRepository.GetDoctorSpecializations(term);
            
            return  AutoMapper.Mapper.Map<IEnumerable<DoctorSpecialization>, List<DoctorSpecializationDto>>(specializations);
        }

        public CollectionResult<DoctorSpecializationDto> GetDoctorSpecializationsByParams(DoctorSpecializationsFilterParams filterParams)
        {
            var specializations = _unitOfWork.DoctorSpecializationRepository.GetDoctorSpecializationsByParams(filterParams);

            var result = new CollectionResult<DoctorSpecializationDto>
            {
                TotalCount = specializations.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<DoctorSpecialization>, List<DoctorSpecializationDto>>(specializations.Collection)
            };

            return result;
        }
    }
}
