import axios from "axios";
import router from "../router";

const baseApiUrl = "http://localhost:53689/";

axios.interceptors.response.use(
    response => {
        return response;
    },
    error => {
        if (error.response.status === 401) {
            router.push("/login");
        }

        return error;
    }
);

let getHeaders = () => {
    let token = localStorage.getItem("token");
    let headers = {};

    if (token) {
        headers = {
            headers: { Authorization: `Bearer ${localStorage.token}` }
        };
    }

    return headers;
};

export const getData = params => {
    const headers = getHeaders();
    return axios.get(baseApiUrl + params.url, headers);
};

export const postData = params => {
    const headers = getHeaders();
    return axios.post(baseApiUrl + params.url, params.data, headers);
};
