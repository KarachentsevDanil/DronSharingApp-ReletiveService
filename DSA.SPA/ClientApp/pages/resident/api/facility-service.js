import * as httpService from '../../../api/http-service';

const apiFacility = "/api/facility/";

export const getFacilitiesByTerm = term => {
    let params = {
        url: apiFacility + `GetFacilitiesByTerm?term=${term}`
    }

    return httpService.getData(params);
}