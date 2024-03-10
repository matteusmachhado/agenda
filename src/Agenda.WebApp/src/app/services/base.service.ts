import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService {

  protected readonly BaseUrl = "https://localhost:7018/api/v1/"

  constructor() {
    
  }
}
