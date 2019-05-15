import * as httpService from '../../../api/http-service';

const apiDepartment = "/api/department/";

export const getDepartmentsByTerm = (term) => {
    let params = {
        url: apiDepartment + `GetDepartmentsByTerm?term=${term}`
    }

    return httpService.getData(params);
}

export const getDepartments = data => {
    let params = {
        url: apiDepartment + "GetDepartments",
        data: data
    }

    return httpService.postData(params);
}

export const addDepartment = data => {
    let params = {
        url: apiDepartment + "AddDepartment",
        data: data
    }

    return httpService.postData(params);
}