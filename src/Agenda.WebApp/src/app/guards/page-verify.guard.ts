import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import _ from 'lodash';
import { AutenticationService } from '../services/autentication.service';

export const pageVerifyGuard: CanActivateFn = (route, state) => {
  return !_.isNull(inject(AutenticationService).getDataOfVerify());
};
