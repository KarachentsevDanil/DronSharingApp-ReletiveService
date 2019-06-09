using System.Collections.Generic;
using RCS.BLL.Dto.Facilities;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IDoctorService
    {
        int AddDoctor(AddDoctorDto data);

        IEnumerable<DoctorDto> GetDoctors(string term);

        CollectionResult<DoctorDto> GetDoctorsByParams(DoctorsFilterParams filterParams);
    }
}
