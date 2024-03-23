import { Component, ElementRef, ViewChild, inject } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NgxSpinnerService } from 'ngx-spinner';
import { AutenticationService } from '../../services/autentication.service';

@Component({
  selector: 'verify-form',
  standalone: true,
  imports: [
    ReactiveFormsModule, 
    MatFormFieldModule, 
    MatInputModule, 
    MatButtonModule
  ],
  templateUrl: './verify-form.component.html',
  styleUrl: './verify-form.component.scss'
})
export class VerifyFormComponent  {

  private formBuilderService = inject(NonNullableFormBuilder);
  private autenticationService = inject(AutenticationService);
  private spinnerService = inject(NgxSpinnerService);
  
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

  onKeyFirst(event: KeyboardEvent){
    this.formVerify.patchValue({first: event.key});
    this.second.nativeElement.focus();
  }

  onKeySecond(event: KeyboardEvent){
    this.formVerify.patchValue({second: event.key});
    this.three.nativeElement.focus();
  }

  onKeyThree(event: KeyboardEvent){
    this.formVerify.patchValue({three: event.key});
    this.four.nativeElement.focus();
  }

  onKeyFour(event: KeyboardEvent){
    this.formVerify.patchValue({four: event.key});
    this.five.nativeElement.focus();
  }

  onKeyFive(event: KeyboardEvent){
    this.formVerify.patchValue({five: event.key});
    this.five.nativeElement.focus();
  }
  
  verify(){
    this.spinnerService.show()
    const code = `${this.formVerify.value.first}${this.formVerify.value.second}${this.formVerify.value.three}${this.formVerify.value.four}${this.formVerify.value.five}`;
    this.autenticationService.verifyCode(code).subscribe(res => this.spinnerService.hide());
  }

}
