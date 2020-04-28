import { Promise } from "@app/common";

export interface IAuthService {
    login(model: any): Promise;
    setAuth(loginResponse: any): void;
}