import { Component } from '@angular/core';
import { LoginFormComponent } from "../../components/login-form/login-form.component";

@Component({
    selector: 'login',
    standalone: true,
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss',
    imports: [LoginFormComponent]
})
export class LoginComponent {

}