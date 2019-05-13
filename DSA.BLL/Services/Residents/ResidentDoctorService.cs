using RCS.BLL.Dto.Residents;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Residents;

namespace RCS.BLL.Services
{
    public class ResidentDoctorService : IResidentDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResidentDoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddResidentDoctor(AddResidentDoctorDto data)
        {
            var newItem = AutoMapper.Mapper.Map<AddResidentDoctorDto, ResidentDoctor>(data);
            _unitOfWork.ResidentDoctorRepository.Add(newItem);
            _unitOfWork.Commit();
        }
    }
}
