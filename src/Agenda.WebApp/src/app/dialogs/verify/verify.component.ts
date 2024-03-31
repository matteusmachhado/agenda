import { Component, Inject, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { VerifyFormComponent } from "../../components/verify-form/verify-form.component";
import { TypeOfVerifyEnum } from '../../enums/type-of-verify';
import { DataOfVerify } from '../../interfaces/data-of-verify';
import { TimerService } from '../../services/timer.service';

@Component({
  selector: 'dialog-verify',
  standalone: true,
  providers: [
    provideNgxMask(),
  ],
  templateUrl: './verify.component.html',
  styleUrl: './verify.component.scss',
  imports: [
    NgxMaskPipe,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    NgxMaskDirective,
    VerifyFormComponent
  ]
})
export class DialogVerifyComponent {

  constructor(@Inject(MAT_DIALOG_DATA) public data: DataOfVerify) { }

  private timerInterval: any;
  private timerService = inject(TimerService);
  private dialog = inject(MatDialogRef<DialogVerifyComponent>);

  typeOfVerifyEnum: typeof TypeOfVerifyEnum = TypeOfVerifyEnum;
  seconds: string = '00';
  minutes: string = '00';

  ngOnInit(): void {
    this.startTimer();
  }

  startTimer() {
    if (!this.timerService.started()) {
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
      this.seconds = '00';
      clearInterval(this.timerInterval);
      this.timerService.clearTimer();
      this.dialog.close();
    } else {
      const minutes = Math.floor(remainingTime / 60000);
      const seconds = ((remainingTime % 60000) / 1000).toFixed(0);
      this.minutes = minutes < 10 ? '0' + minutes : minutes.toString();
      this.seconds = parseInt(seconds) < 10 ? '0' + seconds : seconds.toString();
    }
  }

}
