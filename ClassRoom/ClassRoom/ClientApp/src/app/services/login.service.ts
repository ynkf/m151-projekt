import { LoginModel } from './../models/login.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }

  login(loginData: LoginModel): Observable<any> {
    console.log(loginData);
    return this.httpClient.post('api/user/login', loginData);
  }
}
