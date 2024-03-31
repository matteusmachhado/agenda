import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTabChangeEvent, MatTabsModule } from '@angular/material/tabs';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { DialogVerifyComponent } from '../../dialogs/verify/verify.component';
import { TypeOfVerifyEnum } from '../../enums/type-of-verify';
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
    MatTabsModule,
    NgxMaskDirective,
    MatDialogModule,
    DialogVerifyComponent,
  ],
  providers: [
    provideNgxMask(),
  ],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss',
})
export class LoginFormComponent implements OnInit {

  private formBuilderService = inject(FormBuilder);
  private autenticationService = inject(AutenticationService);
  private spinnerService = inject(NgxSpinnerService);
  private timerService = inject(TimerService)
  private toastr = inject(ToastrService);
  private dialog = inject(MatDialog);

  country: string = '+55';
  typeOfVerifyEnum: typeof TypeOfVerifyEnum = TypeOfVerifyEnum;
  selectedTypeOfVerify: TypeOfVerifyEnum = TypeOfVerifyEnum.SMS;
  
  ngOnInit(): void {
    this.checkRemainingTime();
  }

  checkRemainingTime(){
    const remainingTime = this.timerService.getTimeRemaining();
    if (remainingTime > 0) {
      const dataOfVerify = this.autenticationService.getDataOfVerify();
      this.openDialogVerify(dataOfVerify.sendTo, dataOfVerify.typeOfVerify);
    } 
  }

  formLogin = this.formBuilderService.group({
    phoneNumber: this.formBuilderService.nonNullable.control('', {
      validators: []
    }),
    email: this.formBuilderService.nonNullable.control('', {
      validators: [Validators.email]
    }), 
  });

  tabChange(tab: MatTabChangeEvent){
   this.selectedTypeOfVerify = tab.index;
  }

  login() {
    const sendTo = this.getSendTo();
    const request = this.selectedTypeOfVerify == TypeOfVerifyEnum.SMS ? 
      this.autenticationService.sendCodeBySMS(sendTo) 
      : this.autenticationService.sendCodeByEmail(sendTo);
      
    request.subscribe(() => {
      this.spinnerService.hide();
      this.openDialogVerify(sendTo, this.selectedTypeOfVerify);
      this.toastr.success('Seu código foi enviado com sucesso!');
      this.autenticationService.setDataOfVerify({ sendTo, typeOfVerify: this.selectedTypeOfVerify })
    });
  }

  getSendTo(): string {
    switch(this.selectedTypeOfVerify){
      case TypeOfVerifyEnum.SMS:
        return `${this.country}${this.formLogin.controls.phoneNumber.value}`;
      case TypeOfVerifyEnum.Email:
        return `${this.formLogin.controls.email.value}`;
      default:
        return '';
    }
  }

  openDialogVerify(sendTo: string, typeOfVerify: TypeOfVerifyEnum) {
    const dialog = this.dialog.open(DialogVerifyComponent, { 
      disableClose: true, 
      data: { sendTo, typeOfVerify }
    });

    dialog.afterClosed().subscribe(() => {
      const dataOfVerify = this.autenticationService.getDataOfVerify();
      if (dataOfVerify) {
        if(dataOfVerify.typeOfVerify == this.typeOfVerifyEnum.SMS) this.formLogin.patchValue({ phoneNumber: dataOfVerify.sendTo.substring(3) });
        else if(dataOfVerify.typeOfVerify == this.typeOfVerifyEnum.Email) this.formLogin.patchValue({ email: dataOfVerify.sendTo });
      }
    })
  }
}