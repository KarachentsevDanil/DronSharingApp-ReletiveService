using RCS.BLL.Dto.Residents;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.BLL.Services
{
    public class ResidentDrugService : IResidentDrugService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResidentDrugService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddResidentDrug(AddResidentDrugDto data)
        {
            var newResidentDrug = AutoMapper.Mapper.Map<AddResidentDrugDto, ResidentDrug>(data);
            _unitOfWork.ResidentDrugRepository.Add(newResidentDrug);
            _unitOfWork.Commit();
        }
        
        public CollectionResult<ResidentDrugDto> GetResidentDrugsByParams(ResidentDrugsFilterParams filterParams)
        {
            var items = _unitOfWork.ResidentDrugRepository.GetResidentDrugsByParams(filterParams);

            var result = new CollectionResult<ResidentDrugDto>
            {
                TotalCount = items.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<ResidentDrug>, List<ResidentDrugDto>>(items.Collection)
            };

            return result;
        }
    }
}
