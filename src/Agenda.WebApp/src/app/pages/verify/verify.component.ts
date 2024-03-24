import { Location } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { Router } from '@angular/router';
import _ from 'lodash';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { VerifyFormComponent } from "../../components/verify-form/verify-form.component";
import { DataOfVerify } from '../../interfaces/data-of-verify';

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
export class VerifyComponent implements OnInit {
    
    private location = inject(Location);
    private router = inject(Router);

    data!: DataOfVerify;

    ngOnInit(): void {
        this.data = (this.location.getState() as DataOfVerify);
        if(_.isNil(this.data.sendTo) || _.isNil(this.data.typeOfCheck)) this.router.navigate(['login']);
    }

}