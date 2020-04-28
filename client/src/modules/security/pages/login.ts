import { Component } from "@angular/core";
import { BaseControl, IoCNames } from "@app/common";
import { IAuthService } from "../services/IAuthService";
import { Router } from "@angular/router";

@Component({
    template: `
    <page [title]="i18n.security.title">
        <page-content>
            <div class="row">
                <div class="col-md-4 col-xs-12 col-md-offset-4">
                        <login-form title="i18n.security.auth.login.title" (onLogin)="onLoginClicked($event)"></login-form>
                </div>
            </div>
        </page-content>
    </page>
    `
})
export class Login extends BaseControl {
    private router: Router;
    constructor(router: Router) {
        super();
        this.router = router;
    }
    public onLoginClicked(event: any): void {
        let authService: IAuthService = window.ioc.resolve(IoCNames.IAuthService);
        let self = this;
        authService.login(event).then((loginResponse: any) => {
            self.onLoginSuccess(loginResponse);
        });
    }
    private onLoginSuccess(loginResponse: any): void {
        let authService: IAuthService = window.ioc.resolve(IoCNames.IAuthService);
        authService.setAuth(loginResponse.authToken);
        this.router.navigate(["/inventory"]);
    }
}