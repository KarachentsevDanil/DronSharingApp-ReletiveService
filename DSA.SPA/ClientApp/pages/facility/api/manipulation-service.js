import * as httpService from '../../../api/http-service';

const apiManipulation = "/api/manipulation/";

export const getManipulations = data => {
    let params = {
        url: apiManipulation + "GetManipulations",
        data: data
    }

    return httpService.postData(params);
}

export const addManipulation = data => {
    let params = {
        url: apiManipulation + "AddManipulation",
        data: data
    }

    return httpService.postData(params);
}