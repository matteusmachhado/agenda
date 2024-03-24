import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { TypeOfCheckEnum } from '../../Enums/type-of-check';
import { DataOfVerify } from '../../interfaces/data-of-verify';
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
    NgxMaskDirective,
  ],
  providers: [
    provideNgxMask(),
  ],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss',
})
export class LoginFormComponent {

  country: string = '+55';

  private formBuilderService = inject(FormBuilder);
  private autenticationService = inject(AutenticationService);
  private router = inject(Router);
  private spinnerService = inject(NgxSpinnerService);
  private toastr = inject(ToastrService);

  formLogin = this.formBuilderService.group({
    phoneNumber: this.formBuilderService.nonNullable.control('', {
      validators: [Validators.required]
    })
  });

  login(type: TypeOfCheckEnum) {
    const data: DataOfVerify = { sendTo: this.getSendTo(type), typeOfCheck: type }
    this.autenticationService.sendCode(data.sendTo).subscribe(() => {
      this.spinnerService.hide();
      this.router.navigate(['/verify']);
      this.autenticationService.setDataOfVerify(data);
      this.toastr.success('Seu código foi enviado com sucesso!');
    });
  }

  getSendTo(type: TypeOfCheckEnum): string {
    const phoneNumber = `${this.country}${this.formLogin.value.phoneNumber}`;
    return TypeOfCheckEnum.SMS == type ? phoneNumber : '';
  }

}
