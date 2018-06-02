import * as httpService from '../../../api/http-service';

const apiDoctor = "/api/doctor/";

export const getDoctorsByTerm = term => {
    let params = {
        url: apiDoctor + `getDoctorsByTerm?term=${term}`
    }

    return httpService.getData(params);
}

export const getDoctorSpecializationsByTerm = term => {
    let params = {
        url: apiDoctor + `getDoctorSpecializationsByTerm?term=${term}`
    }

    return httpService.getData(params);
}

export const addDoctor = data => {
    let params = {
        url: apiDoctor + "addDoctor",
        data: data
    }

    return httpService.postData(params);
}

export const addDoctorSpecialization = data => {
    let params = {
        url: apiDoctor + "addDoctorSpecialization",
        data: data
    }

    return httpService.postData(params);
}

export const getDoctors = data => {
    let params = {
        url: apiDoctor + "getDoctors",
        data: data
    }

    return httpService.postData(params);
}

export const getDoctorSpecializations = data => {
    let params = {
        url: apiDoctor + "getDoctorSpecializations",
        data: data
    }

    return httpService.postData(params);
}