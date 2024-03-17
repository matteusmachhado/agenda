import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideToastr } from 'ngx-toastr';
import { routes } from './app.routes';
import { HttpErrorHandlerInterceptor } from './interceptors/http-error-handler';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes), 
    provideHttpClient(withFetch(), withInterceptors([HttpErrorHandlerInterceptor])),
    provideClientHydration(), 
    provideAnimationsAsync(),
    provideToastr({
      positionClass: 'toast-bottom-right',
      progressBar: true,
      closeButton: true
    })
  ]
};
