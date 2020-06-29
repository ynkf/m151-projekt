import { LoginModel } from './../../models/login.model';
import { LoginService } from './../../services/login.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginData: LoginModel;

  constructor(private loginService: LoginService) {
    this.loginData = new LoginModel();
  }

  login() {
    this.loginService.login(this.loginData);
  }
}
