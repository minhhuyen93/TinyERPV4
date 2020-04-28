import { IIoCRegistration, IoCNames, IoCLifecycle, ResourceService, AppSettingService } from "@app/common";
import { ProductService } from "../../modules/inventory/services/productService";
import { EventManager } from "@app/common";
import { AuthService } from "../../modules/security/services/authService";
import { CacheService } from "@app/common";
let registrations: Array<IIoCRegistration> = [
    { name: IoCNames.IResourceService, lifecycle: IoCLifecycle.Singleton, instanceOf: ResourceService },
    { name: IoCNames.IProductService, lifecycle: IoCLifecycle.Transient, instanceOf: ProductService },
    { name: IoCNames.IAppSettingService, lifecycle: IoCLifecycle.Singleton, instanceOf: AppSettingService },
    { name: IoCNames.IEventManager, lifecycle: IoCLifecycle.Singleton, instanceOf: EventManager },
    { name: IoCNames.IAuthService, lifecycle: IoCLifecycle.Transient, instanceOf: AuthService },
    { name: IoCNames.ICacheService, lifecycle: IoCLifecycle.Singleton, instanceOf: CacheService },
];
export default registrations;