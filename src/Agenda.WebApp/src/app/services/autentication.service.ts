import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AutenticationService extends BaseService {

  constructor(private httpClientService: HttpClient) {
    super();
   }

  sendCode(phoneNumber: string) : Observable<any>{
    const uri = this.BaseUrl + "client/send-verification-code-sms"
    const body = { phoneNumber };
    
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    return this.httpClientService.post(uri, body);
  }

  verifyCode(code: string) : Observable<any>{
    const uri = this.BaseUrl + "client/verify"
    const body = { code };
    
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    return this.httpClientService.post(uri, body);
  }

}
