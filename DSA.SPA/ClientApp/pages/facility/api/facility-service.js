import * as httpService from '../../../api/http-service';

const apiFacility = "/api/facility/";

export const getFacilitiesByTerm = term => {
    let params = {
        url: apiFacility + `GetFacilitiesByTerm?term=${term}`
    }

    return httpService.getData(params);
}

export const getFacilities = data => {
    let params = {
        url: apiFacility + "getFacilities",
        data: data
    }

    return httpService.postData(params);
}

export const addFacility = data => {
    let params = {
        url: apiFacility + "addFacility",
        data: data
    }

    return httpService.postData(params);
}