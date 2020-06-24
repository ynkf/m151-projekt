import { ErrorService } from './../../services/error.service';
import { TextConstantService } from './../../services/textConstant.service';
import { LoginModel } from './../../models/login.model';
import { LoginService } from './../../services/login.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginData: LoginModel;
  errors: string[];

  constructor(
    private router: Router,
    private loginService: LoginService,
    private errorService: ErrorService,
    private textConstantService: TextConstantService
  ) {
    this.loginData = new LoginModel();
  }

  login( ) {
    this.errorService.clearErrors();

    this.loginService
      .login(this.loginData)
      .subscribe(isAuthorized => {
        if (isAuthorized) {
          this.router.navigate(['home']);
        } else {
          this.errorService.showError(this.textConstantService.LOGIN_FAILED);
        }
      });
  }
}
