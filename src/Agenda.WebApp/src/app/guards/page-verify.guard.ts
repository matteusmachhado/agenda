import { CanActivateFn } from '@angular/router';

export const pageVerifyGuard: CanActivateFn = (route, state) => {
  return true;
};
