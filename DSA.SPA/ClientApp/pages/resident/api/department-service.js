import * as httpService from '../../../api/http-service';

const apiDepartment = "/api/department/";

export const getDepartmentsByTerm = term => {
    let params = {
        url: apiDepartment + `GetDepartmentsByTerm?term=${term}`
    }

    return httpService.getData(params);
}