using RCS.BLL.Dto.Facilities;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.BLL.Services
{
    public class DrugService : IDrugService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrugService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddDrug(AddDrugDto data)
        {
            var newDrug = AutoMapper.Mapper.Map<AddDrugDto, Drug>(data);
            _unitOfWork.DrugRepository.Add(newDrug);
            _unitOfWork.Commit();
        }
        
        public CollectionResult<DrugDto> GetDrugsByParams(DrugsFilterParams filterParams)
        {
            var items = _unitOfWork.DrugRepository.GetDrugsByParams(filterParams);

            var result = new CollectionResult<DrugDto>
            {
                TotalCount = items.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Drug>, List<DrugDto>>(items.Collection)
            };

            return result;
        }
    }
}
