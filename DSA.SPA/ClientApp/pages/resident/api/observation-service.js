import * as httpService from '../../../api/http-service';

const apiObservation = "/api/observation/";

export const getObservations = data => {
    let params = {
        url: apiObservation + `GetObservationsByParams`,
        data: data
    }

    return httpService.postData(params);
}

export const getObservationsByType = data => {
    let params = {
        url: apiObservation + `GetObservation`,
        data: data
    }

    return httpService.postData(params);
}