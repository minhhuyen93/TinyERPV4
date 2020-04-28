import { IConnector } from "./iconnector";
import { ConnectorType, IoCNames } from "../models/enums";
import { Promise, PromiseFactory } from "../models/promise";
import { Http, Headers } from "@angular/http";
import "rxjs/add/operator/map";
import { ResponseModel } from "../models/responseModel";
import { IEventManager } from "../services/ieventManager";
import { ValidationResult } from "../models/ivalidationResult";
import { JsonHeaders } from "./jsonHeaders";
export class ConnectorFactory {
    public static create(type: ConnectorType): IConnector {
        switch (type) {
            case ConnectorType.Json:
            default:
                return new JsonConnector();
        }
    }
}
class JsonConnector implements IConnector {
    public get(url: string): Promise {
        let def: Promise = PromiseFactory.create();
        let http: Http = window.ioc.resolve(Http);
        let self = this;
        let headers: Headers = this.getHeader();
        http.get(url, { headers: headers }).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            self.processResponse(def, data);
        });
        return def;
    }
    public delete(url: string): Promise {
        let def: Promise = PromiseFactory.create();
        let http: Http = window.ioc.resolve(Http);
        let self = this;
        let headers: Headers = this.getHeader();
        http.delete(url, { headers: headers }).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            self.processResponse(def, data);
        });
        return def;
    }
    public post(url: string, item: any): Promise {
        let def: Promise = PromiseFactory.create();
        let http: Http = window.ioc.resolve(Http);
        let newDataItem: any = this.toJson(item);
        let self = this;
        let headers: Headers = this.getHeader();
        http.post(url, newDataItem, { headers: headers }).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            self.processResponse(def, data);
        }, (error: ResponseModel) => {
            self.processResponse(def, error);
        });
        return def;
    }
    private getHeader(): Headers {
        return new JsonHeaders();
    }
    private processResponse(def: Promise, response: ResponseModel): void {
        if (!response || !response.hasOwnProperty("data")) {
            def.resolve(response);
            return;
        }
        if (response.errors != null && response.errors.length > 0) {
            let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
            response.errors.forEach((error: any) => {
                eventManager.publish(new ValidationResult(error.errorKey, false));
            });
            def.reject(response.errors);
            return;
        }
        if (response && response.hasOwnProperty("data")) {
            def.resolve(response.data);
        }
    }
    private toJson(item: any): any {
        let newDataItem: any = {};
        for (let prop in item) {
            if (prop.startsWith("_")) {
                let newProp = prop.substr(1);
                newDataItem[newProp] = item[prop];
            } else {
                newDataItem[prop] = item[prop];
            }
        }
        return newDataItem;
    }
}