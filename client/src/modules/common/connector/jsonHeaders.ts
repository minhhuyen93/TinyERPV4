import { Headers } from "@angular/http";
import { ICacheService } from "../services/icacheService";
import { IoCNames, CACHE_CONTANST } from "../models/enums";

export class JsonHeaders extends Headers {
    constructor(requiredAuthoInfor: boolean = true) {
        super();
        this.append("Content-Type", "application/json");
        this.append("Accept", "application/json");
        if (!requiredAuthoInfor) { return; }
        let cacheService: ICacheService = window.ioc.resolve(IoCNames.ICacheService);
        let token: string = cacheService.get(CACHE_CONTANST.TOKEN);
        token = String.format("Bearer {0}", token);
        this.append("Authorization", token);
    }
}