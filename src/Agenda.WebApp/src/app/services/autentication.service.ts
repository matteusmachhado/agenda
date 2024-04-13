import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import _ from 'lodash';
import { Observable } from 'rxjs';
import { DataOfVerify } from '../interfaces/data-of-verify';
import { ResponseLogin } from '../interfaces/response-login';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AutenticationService extends BaseService {

  constructor(private httpClientService: HttpClient) {
    super();
  }

  sendCodeBySMS(phoneNumber: string) : Observable<any>{
    const uri = this.BaseUrl + "client/send-verification-code-sms"
    const body = { phoneNumber };
    
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    return this.httpClientService.post(uri, body);
  }

  sendCodeByEmail(email: string) : Observable<any>{
    const uri = this.BaseUrl + "client/send-verification-code-email"
    const body = { email };
    
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

  setDataOfVerify(data: DataOfVerify){
    localStorage.setItem("data", JSON.stringify(data));
  }

  getDataOfVerify(): DataOfVerify{
    const data = localStorage.getItem("data");
    return data ? JSON.parse(data) : null;
  }

  public setToken(response: ResponseLogin): void {
    sessionStorage.setItem('token', JSON.stringify(response));
  }

  public getToken(): string | null {
    const obj = sessionStorage.getItem('token');
    return _.isNull(obj) ? null : (JSON.parse(obj) as ResponseLogin).accessToken;
  }

}
