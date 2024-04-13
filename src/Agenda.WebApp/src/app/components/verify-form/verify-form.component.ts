import { Component, ElementRef, ViewChild, inject } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { DialogVerifyComponent } from '../../dialogs/verify/verify.component';
import { AutoFocusDirective } from '../../directives/auto-focus.directive';
import { ResponseLogin } from '../../interfaces/response-login';
import { AutenticationService } from '../../services/autentication.service';
import { TimerService } from '../../services/timer.service';

@Component({
  selector: 'verify-form',
  standalone: true,
  imports: [
    ReactiveFormsModule, 
    MatFormFieldModule, 
    MatInputModule, 
    MatButtonModule,
    AutoFocusDirective
  ],
  templateUrl: './verify-form.component.html',
  styleUrl: './verify-form.component.scss'
})
export class VerifyFormComponent  {

  private formBuilderService = inject(NonNullableFormBuilder);
  private autenticationService = inject(AutenticationService);
  private spinnerService = inject(NgxSpinnerService);
  private dialogVerify = inject(MatDialogRef<DialogVerifyComponent>);
  private timerService = inject(TimerService);
  private router = inject(Router);
  
  @ViewChild("first") first!: ElementRef;
  @ViewChild("second") second!: ElementRef;
  @ViewChild("three") three!: ElementRef;
  @ViewChild("four") four!: ElementRef;
  @ViewChild("five") five!: ElementRef;

  formVerify = this.formBuilderService.group({
    first: this.formBuilderService.control('', {
      validators: [Validators.required, Validators.maxLength(1)]
    }),
    second: this.formBuilderService.control('', {
      validators: [Validators.required, Validators.maxLength(1)]
    }),
    three: this.formBuilderService.control('', {
      validators: [Validators.required, Validators.maxLength(1)]
    }),
    four: this.formBuilderService.control('', {
      validators: [Validators.required, Validators.maxLength(1)]
    }),
    five: this.formBuilderService.control('', {
      validators: [Validators.required, Validators.maxLength(1)]
    }),
  });

  validation(event: KeyboardEvent) : boolean{
    return (/^[a-zA-Z0-9]{1}$/.test(event.key));
  }

  onKeyFirst(event: KeyboardEvent){
    if(!this.validation(event)) return;
    this.formVerify.patchValue({first: event.key});
    this.second.nativeElement.focus();
  }

  onKeySecond(event: KeyboardEvent){
    if(!this.validation(event)) return;
    this.formVerify.patchValue({second: event.key});
    this.three.nativeElement.focus();
  }

  onKeyThree(event: KeyboardEvent){
    if(!this.validation(event)) return;
    this.formVerify.patchValue({three: event.key});
    this.four.nativeElement.focus();
  }

  onKeyFour(event: KeyboardEvent){
    if(!this.validation(event)) return;
    this.formVerify.patchValue({four: event.key});
    this.five.nativeElement.focus();
  }

  onKeyFive(event: KeyboardEvent){
    if(!this.validation(event)) return;
    this.formVerify.patchValue({five: event.key});
    this.five.nativeElement.focus();
  }
  
  verify(){
    this.spinnerService.show()
    const code = `${this.formVerify.value.first}${this.formVerify.value.second}${this.formVerify.value.three}${this.formVerify.value.four}${this.formVerify.value.five}`;
    this.autenticationService.verifyCode(code).subscribe((res: ResponseLogin) => {
      this.dialogVerify.close();
      this.timerService.clearTimer();
      this.spinnerService.hide();
      this.autenticationService.setToken(res);
      this.router.navigate(['account/profile'])
    });
  }

}
