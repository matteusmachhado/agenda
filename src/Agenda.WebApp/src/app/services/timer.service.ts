import { Injectable } from '@angular/core';
import _ from 'lodash';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class TimerService extends BaseService  {

  public timer: number = 2;
  private key: string = 'timer';

  constructor() {
    super();
  }

  startTimer() {
    const endTime = new Date().getTime() + this.timer * 60 * 1000;
    localStorage.setItem(this.key, endTime.toString());
  }

  getTimeRemaining(): number {
    const endTime = parseInt(localStorage.getItem(this.key) || '0', 10);
    const currentTime = new Date().getTime();
    return Math.max(0, endTime - currentTime);
  }

  clearTimer() {
    localStorage.removeItem(this.key);
  }

  started(): boolean{
    return !_.isNil(localStorage.getItem(this.key));
  }
}
