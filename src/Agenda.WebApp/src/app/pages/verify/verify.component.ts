import { Component, Input } from '@angular/core';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { VerifyFormComponent } from "../../components/verify-form/verify-form.component";

@Component({
    selector: 'verify',
    standalone: true,
    imports: [
        NgxMaskPipe,
        VerifyFormComponent,
        NgxMaskDirective,
    ],
    providers:[
        provideNgxMask(),
    ],
    templateUrl: './verify.component.html',
    styleUrl: './verify.component.scss',
})
export class VerifyComponent {

    @Input('sendTo') sendTo: string = '';

}
