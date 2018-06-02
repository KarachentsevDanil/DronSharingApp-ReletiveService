import * as httpService from '../../../api/http-service';

const apiAppointment = "/api/appointment/";

export const addAppointment = data => {
    let params = {
        url: apiAppointment + `AddAppointment`,
        data: data
    }

    return httpService.postData(params);
}

export const getAppointments = data => {
    let params = {
        url: apiAppointment + `GetAppointments`,
        data: data
    }

    return httpService.postData(params);
}