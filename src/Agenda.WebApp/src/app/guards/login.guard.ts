import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import _ from 'lodash';
import { AutenticationService } from '../services/autentication.service';

export const loginGuard: CanActivateFn = (route, state) => {
  const token = inject(AutenticationService).getToken();
  return _.isNull(token);
};
