import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
let routes: Routes = [
    { path: "", redirectTo: "security", pathMatch: "full" },
    { path: "security", loadChildren: "src/modules/security/securityModule#SecurityModule" },
    { path: "inventory", loadChildren: "src/modules/inventory/inventoryModule#InventoryModule" }
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [RouterModule],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppRoutes { }