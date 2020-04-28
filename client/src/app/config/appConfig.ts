import { IConfigModel } from "@app/common";

let appConfig: IConfigModel = {
    domains: [
        {
            key: "InventoryApi",
            value: "http://testlocalhost.inventory.api/api"
        },
        {
            key: "SercurityApiKey",
            value: "http://testlocalhost.security.api/api"
        }
    ]
};
export default appConfig;