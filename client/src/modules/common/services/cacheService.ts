import { ICacheService } from "./icacheService";

export class CacheService implements ICacheService {
    public set(key: string, data: any): any {
        return sessionStorage.setItem(key, JSON.stringify(data));
    }
    public get(key: string): string {
        let value: string = sessionStorage.getItem(key);
        if (String.isNullOrWhiteSpace(value)) {
            return "";
        }
        return JSON.parse(value);
    }
}