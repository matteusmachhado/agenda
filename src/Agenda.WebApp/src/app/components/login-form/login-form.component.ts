import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { DialogVerifyComponent } from '../../dialogs/verify/verify.component';
import { TypeOfCheckEnum } from '../../enums/type-of-check';
import { AutenticationService } from '../../services/autentication.service';
import { TimerService } from '../../services/timer.service';

@Component({
  selector: 'login-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    NgxMaskDirective,
    MatDialogModule,
    DialogVerifyComponent
  ],
  providers: [
    provideNgxMask(),
  ],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss',
})
export class LoginFormComponent implements OnInit {

  country: string = '+55';

  private formBuilderService = inject(FormBuilder);
  private autenticationService = inject(AutenticationService);
  private spinnerService = inject(NgxSpinnerService);
  private timerService = inject(TimerService)
  private toastr = inject(ToastrService);
  private dialog = inject(MatDialog);

  ngOnInit(): void {
    const remainingTime = this.timerService.getTimeRemaining();
    if (remainingTime > 0) {
      const data = this.autenticationService.getDataOfVerify();
      this.openDialogVerify(data.sendTo);
    }
  }

  formLogin = this.formBuilderService.group({
    phoneNumber: this.formBuilderService.nonNullable.control('', {
      validators: [Validators.required]
    })
  });

  login(typeEnum: TypeOfCheckEnum) {
    const sendTo = this.getSendTo(typeEnum);
    this.autenticationService.setDataOfVerify({ sendTo, typeOfCheck: typeEnum })
    this.autenticationService.sendCode(sendTo).subscribe(() => {
      this.spinnerService.hide();
      this.openDialogVerify(sendTo);
      this.toastr.success('Seu código foi enviado com sucesso!');
    });
  }

  getSendTo(typeEnum: TypeOfCheckEnum): string {
    switch(typeEnum){
      case TypeOfCheckEnum.SMS:
        return `${this.country}${this.formLogin.value.phoneNumber}`;
      case TypeOfCheckEnum.Email:
        return '';
      default:
        return '';
    }
  }

  openDialogVerify(sendTo: string) {
    this.dialog.open(DialogVerifyComponent, { 
        disableClose: true, 
        data: { sendTo }
      });
  }
}