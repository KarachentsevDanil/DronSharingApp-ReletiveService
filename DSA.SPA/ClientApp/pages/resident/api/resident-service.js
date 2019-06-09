import * as httpService from '../../../api/http-service';

const apiResident = "/api/resident/";
const apiAnalyzes = "/api/Analyzes/";
const apiDrugs = "/api/Drug/";
const apiManipulations = "/api/Manipulation/";

export const getResidentById = id => {
    let params = {
        url: apiResident + `GetResidentById?id=${id}`
    }

    return httpService.getData(params);
}

export const getResidentsByTerm = term => {
    let params = {
        url: apiResident + `GetResidentsByTerm?term=${term}`
    }

    return httpService.getData(params);
}

export const getResidents = data => {
    let params = {
        url: apiResident + "getResidents",
        data: data
    }

    return httpService.postData(params);
}

export const getResidentContacts = data => {
    let params = {
        url: apiResident + "getResidentContacts",
        data: data
    }

    return httpService.postData(params);
}

export const addResident = data => {
    let params = {
        url: apiResident + "addResident",
        data: data
    }

    return httpService.postData(params);
}

export const addResidentDoctor = data => {
    let params = {
        url: apiResident + "addResidentDoctor",
        data: data
    }

    return httpService.postData(params);
}

export const addResidentContact = data => {
    let params = {
        url: apiResident + "addResidentContact",
        data: data
    }

    return httpService.postData(params);
}

export const updateResidentContact = data => {
    let params = {
        url: apiResident + "updateResidentContact",
        data: data
    }

    return httpService.postData(params);
}

export const addResidentAnalyze = data => {
    let params = {
        url: apiResident + "AddResidentAnalyzes",
        data: data
    }

    return httpService.postData(params);
}

export const addResidentDrug = data => {
    let params = {
        url: apiResident + "AddResidentDrug",
        data: data
    }

    return httpService.postData(params);
}

export const addResidentManipulation = data => {
    let params = {
        url: apiResident + "AddResidentManipulation",
        data: data
    }

    return httpService.postData(params);
}

export const getResidentAnalyzes = data => {
    let params = {
        url: apiResident + "GetResidentAnalyzes",
        data: data
    }

    return httpService.postData(params);
}

export const getResidentDrugs = data => {
    let params = {
        url: apiResident + "GetResidentDrugs",
        data: data
    }

    return httpService.postData(params);
}

export const getResidentManipulations = data => {
    let params = {
        url: apiResident + "GetResidentManipulations",
        data: data
    }

    return httpService.postData(params);
}

export const getAnalyzes = () => {
    let params = {
        url: apiAnalyzes + "GetAnalyzesByTerm"
    }

    return httpService.getData(params);
}

export const getDrugs = () => {
    let params = {
        url: apiDrugs + "GetDrugsByTerm"
    }

    return httpService.getData(params);
}

export const getManipulations = () => {
    let params = {
        url: apiManipulations + "GetManipulationsByTerm"
    }

    return httpService.getData(params);
}

export const getResidentTimeline = (residentId) => {
    let params = {
        url: apiResident + "GetResidentTimeline?residentId=" + residentId
    }

    return httpService.getData(params);
}