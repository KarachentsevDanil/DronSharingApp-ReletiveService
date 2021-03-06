﻿using System.Collections.Generic;
using RCS.BLL.Dto.Facilities;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IDepartmentService
    {
        void AddDepartment(AddDepartmentDto data);
        
        CollectionResult<DepartmentDto> GetDepartmentsByParams(DepartmentsFilterParams filterParams);

        IEnumerable<DepartmentDto> GetDepartmentsByTerm(int facilityId, string term);
    }
}