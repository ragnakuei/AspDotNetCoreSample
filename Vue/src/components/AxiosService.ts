import axios, { AxiosInstance } from "axios";
import router from "@/router";
import { AuthModule, ReturnUrlModule } from "@/store";

export class AxiosService {
    public instance: AxiosInstance;

    constructor() {
        this.instance = axios.create({
            baseURL: process.env.VUE_APP_ApiHost,
            timeout: 5000,
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
        });
    }
}
