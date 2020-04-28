import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { Login } from "./pages/login";
import { AppCommonModule } from "@app/common";
let routes: Routes = [
    { path: "", redirectTo: "login", pathMatch: "full" },
    { path: "login", component: Login }
];
@NgModule({
    imports: [
        AppCommonModule,
        RouterModule.forChild(routes)
    ],
    declarations: [
        Login
    ]
})
export class SecurityRoutes { }