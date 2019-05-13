using System.Collections.Generic;
using RCS.BLL.Dto.Residents;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.BLL.Services
{
    public class ObservationService : IObservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddObservation(AddObservationDto data)
        {
            var newItem = AutoMapper.Mapper.Map<AddObservationDto, Observation>(data);
            _unitOfWork.ObservationRepository.Add(newItem);
            _unitOfWork.Commit();
        }

        public CollectionResult<ObservationDto> GetObservationsByParams(ObservationParams filterParams)
        {
            var observations = _unitOfWork.ObservationRepository.GetResidentObservations(filterParams);

            var result = new CollectionResult<ObservationDto>
            {
                TotalCount = observations.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Observation>, List<ObservationDto>>(observations.Collection)
            };

            return result;
        }
    }
}
