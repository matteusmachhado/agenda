import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { TimerServiceService } from '../services/timer.service';

export const pageLoginGuard: CanActivateFn = (route, state) => {
  return !(inject(TimerServiceService).started());
};
