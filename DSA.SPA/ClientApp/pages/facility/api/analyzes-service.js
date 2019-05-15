import * as httpService from '../../../api/http-service';

const apiAnalyzes = "/api/analyzes/";

export const getAnalyzes = data => {
    let params = {
        url: apiAnalyzes + "GetAnalyzes",
        data: data
    }

    return httpService.postData(params);
}

export const addAnalyzes = data => {
    let params = {
        url: apiAnalyzes + "AddAnalyzes",
        data: data
    }

    return httpService.postData(params);
}