import { Component, Input, Output, EventEmitter } from "@angular/core";
import { BaseControl } from "../baseControl";
import { required } from "../../decorators/required";
import { BaseModel } from "../../models/baseModel";

@Component({
    selector: "login-form",
    template: `
    <form-horizontal>
        <form-text-input [title]="i18n.security.auth.userName" 
        [validations]="[
            'security.auth.useNameWasRequired','security.auth.userNameOrPasswordInValid']"
            [(model)]=model.userName>
        </form-text-input>
        <form-password-input [title]="i18n.security.auth.password"
        [validations]="[
            'security.auth.passwordWasRequired','security.auth.passwordNotFound']"
        [(model)]=model.password>
        </form-password-input>
        <form-buttons>
            <button-primary (onClicked)="onLoginClicked($event)" [text]="i18n.common.login"></button-primary>
        </form-buttons>
    </form-horizontal>
    `
})
export class LoginForm extends BaseControl {
    @Input() title: string;
    public model: LoginFormModel;
    @Output() onLogin: EventEmitter<any> = new EventEmitter();
    constructor() {
        super();
        this.model = new LoginFormModel();
    }
    public onLoginClicked(): void {
        if (!this.model.isValid()) { return; }
        this.onLogin.emit(this.model);
    }
}

class LoginFormModel extends BaseModel {
    @required("security.auth.useNameWasRequired")
    public userName: string;
    @required("security.auth.passwordWasRequired")
    public password: string;
}