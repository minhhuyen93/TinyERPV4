import { IAuthService } from "./IAuthService";
import { BaseService, Promise, IConnector, ConnectorFactory, ConnectorType, IoCNames } from "@app/common";
import { Sercurity } from "../models/enums";

import { AuthToken } from "@app/common";
import { ICacheService, CACHE_CONTANST } from "@app/common";
export class AuthService extends BaseService implements IAuthService {
    private cacheService: ICacheService;
    constructor() {
        super(Sercurity.ApiKey);
        this.cacheService = window.ioc.resolve(IoCNames.ICacheService);
    }
    public login(model: any): Promise {
        let url: string = "/security/login";
        let connector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        return connector.post(this.resolveUrl(url), model);
    }

    public setAuth(auth: any): void {
        this.cacheService.set(CACHE_CONTANST.TOKEN, auth);
    }
}