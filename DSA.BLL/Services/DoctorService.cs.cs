using System.Collections.Generic;
using RCS.BLL.Dto.Facilities;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Facilities;
using RCS.Domain.Params;

namespace RCS.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        

        public void AddDoctor(AddDoctorDto data)
        {
            var newDoctor = AutoMapper.Mapper.Map<AddDoctorDto, Doctor>(data);
            _unitOfWork.DoctorRepository.Add(newDoctor);
            _unitOfWork.Commit();
        }
        
        public IEnumerable<DoctorDto> GetDoctors(string term)
        {
            var doctors = _unitOfWork.DoctorRepository.GetDoctors(term);

            return AutoMapper.Mapper.Map<IEnumerable<Doctor>, List<DoctorDto>>(doctors);
        }

        public CollectionResult<DoctorDto> GetDoctorsByParams(DoctorsFilterParams filterParams)
        {
            var doctors = _unitOfWork.DoctorRepository.GetDoctorsByParams(filterParams);

            var result = new CollectionResult<DoctorDto>
            {
                TotalCount = doctors.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Doctor>, List<DoctorDto>>(doctors.Collection)
            };

            return result;
        }
    }
}
