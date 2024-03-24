import { Component, OnInit, inject } from '@angular/core';
import _ from 'lodash';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { TypeOfCheckEnum } from '../../Enums/type-of-check';
import { VerifyFormComponent } from "../../components/verify-form/verify-form.component";
import { AutenticationService } from '../../services/autentication.service';
import { TimerServiceService } from '../../services/timer.service';

@Component({
    selector: 'verify',
    standalone: true,
    imports: [
        NgxMaskPipe,
        VerifyFormComponent,
        NgxMaskDirective,
    ],
    providers: [
        provideNgxMask(),
    ],
    templateUrl: './verify.component.html',
    styleUrl: './verify.component.scss',
})
export class VerifyComponent implements OnInit {

    private timerInterval: any;

    private autenticationService = inject(AutenticationService);
    private timerService = inject(TimerServiceService);

    sendTo: string = '';
    typeOfCheck: TypeOfCheckEnum = TypeOfCheckEnum.SMS;
    seconds: string = '00';
    minutes: string = '00';
    
    ngOnInit(): void {
        const data = this.autenticationService.getDataOfVerify();
        if(!_.isNull(data)){
            this.sendTo = data.sendTo;
            this.typeOfCheck = data.typeOfCheck;
        }
        
        this.startTimer();
    }

    startTimer() {
        if(!this.timerService.started()){
            this.timerService.startTimer();
        }
        this.updateTime();
        this.timerInterval = setInterval(() => {
            this.updateTime();
        }, 1000);
    }

    updateTime() {
        const remainingTime = this.timerService.getTimeRemaining();
        if (remainingTime === 0) {
            clearInterval(this.timerInterval);
            this.timerService.clearTimer();
        } else {
            const minutes = Math.floor(remainingTime / 60000);
            const seconds = ((remainingTime % 60000) / 1000).toFixed(0);
            this.minutes = minutes < 10 ? '0' + minutes : minutes.toString();
            this.seconds = parseInt(seconds) < 10 ? '0' + seconds : seconds.toString();
        }
    }
}