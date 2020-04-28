export interface ICacheService {
    set(key: string, data: any): any;
    get(key: string): string;
}