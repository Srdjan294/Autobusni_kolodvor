import axios from "axios";


export const HttpService = axios.create({

    baseURL: 'https://srdjan294-001-site1.anytempurl.com/api/v1',
    headers: {
        'Content-Type' : 'application/json'
    }


});