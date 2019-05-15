import * as httpService from '../../../api/http-service';

const apiDrug = "/api/drug/";

export const getDrugsByTerm = term => {
    let params = {
        url: apiDrug + `GetDrugsByTerm?term=${term}`
    }

    return httpService.getData(params);
}

export const getDrugs = data => {
    let params = {
        url: apiDrug + "getDrugs",
        data: data
    }

    return httpService.postData(params);
}

export const addDrug = data => {
    let params = {
        url: apiDrug + "addDrug",
        data: data
    }

    return httpService.postData(params);
}