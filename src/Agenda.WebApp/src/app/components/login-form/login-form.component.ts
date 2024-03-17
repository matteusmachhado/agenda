import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';
import { NgxSpinnerService } from 'ngx-spinner';
import { AutenticationService } from '../../services/autentication.service';

@Component({
  selector: 'login-form',
  standalone: true,
  imports: [
    ReactiveFormsModule, 
    MatFormFieldModule, 
    MatInputModule, 
    MatButtonModule,
    MatIconModule,
    NgxMaskDirective
  ],
  providers:[
    provideNgxMask(),
  ],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss',
})
export class LoginFormComponent {

  private formBuilderService = inject(FormBuilder);
  private autenticationService = inject(AutenticationService);
  private router = inject(Router);
  private spinnerService = inject(NgxSpinnerService);

  formLogin = this.formBuilderService.group({
    phoneNumber: this.formBuilderService.nonNullable.control('', {
      validators: [Validators.required]
    })
  });

  login(){
    this.spinnerService.show();
    const phoneNumber = this.formLogin.value.phoneNumber;
    if(!phoneNumber) return;
    this.autenticationService.sendCode(phoneNumber).subscribe(() => {
      this.spinnerService.hide();
      this.router.navigate(['/verify'])
    });
  }

}
