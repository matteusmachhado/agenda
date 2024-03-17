import { HttpErrorResponse, HttpEvent, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Observable, catchError, map, throwError } from 'rxjs';

export const HttpErrorHandlerInterceptor: HttpInterceptorFn = (request, next):
 Observable<HttpEvent<any>> => {
  const spinnerService = inject(NgxSpinnerService);
  const toastr = inject(ToastrService);
  return next(request).pipe(
    map((request: any) => {
      spinnerService.show();
      return request;
    }),
    catchError((response: HttpErrorResponse) => {
      const hasError = response.error.errors.length;
      if(hasError){
        toastr.error(response.error.errors[0], 'Erro');
      }else{
        toastr.error('Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.', 'Erro');
      }
      spinnerService.hide();
      return throwError(() => response); 
    })
  );
};
