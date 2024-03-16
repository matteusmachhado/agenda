import { Component } from '@angular/core';
import { VerifyFormComponent } from "../../components/verify-form/verify-form.component";

@Component({
    selector: 'app-verify',
    standalone: true,
    templateUrl: './verify.component.html',
    styleUrl: './verify.component.scss',
    imports: [VerifyFormComponent]
})
export class VerifyComponent {

}
