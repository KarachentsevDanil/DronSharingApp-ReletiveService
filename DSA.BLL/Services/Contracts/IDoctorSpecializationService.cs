using RCS.BLL.Dto.Facilities;
using RCS.Domain.Params;
using System.Collections.Generic;

namespace RCS.BLL.Services.Contracts
{
    public interface IDoctorSpecializationService
    {
        void AddDoctorSpecialization(AddDoctorSpecializationDto data);

        IEnumerable<DoctorSpecializationDto> GetDoctorSpecializationByTerm(string term);

        CollectionResult<DoctorSpecializationDto> GetDoctorSpecializationsByParams(DoctorSpecializationsFilterParams filterParams);
    }
}
