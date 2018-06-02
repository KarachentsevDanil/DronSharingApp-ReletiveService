import * as httpService from '../../../api/http-service';

const apiUser = "/api/account/";

export const getUsers = data => {
    let params = {
        url: apiUser + "getUsers",
        data: data
    }

    return httpService.postData(params);
}

export const addUser = data => {
    let params = {
        url: apiUser + "register",
        data: data
    }

    return httpService.postData(params);
}