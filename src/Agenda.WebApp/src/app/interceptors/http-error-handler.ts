import { HttpEvent, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable, catchError, map, throwError } from 'rxjs';

export const HttpErrorHandlerInterceptor: HttpInterceptorFn = (request, next):
 Observable<HttpEvent<any>> => {
  const spinnerService = inject(NgxSpinnerService);
  return next(request).pipe(
    map((request: any) => {
      spinnerService.show();
      return request;
    }),
    catchError((error: any) => {
      spinnerService.hide();
      return throwError(() => error); 
    })
  );
};
