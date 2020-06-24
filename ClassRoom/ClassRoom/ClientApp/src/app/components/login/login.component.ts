import { UnSubscribable } from './../../base-classes/unsubscribable';
import { ErrorService } from './../../services/error.service';
import { TextConstantService } from './../../services/textConstant.service';
import { LoginModel } from './../../models/login.model';
import { LoginService } from './../../services/login.service';
import { takeUntil, catchError } from 'rxjs/operators';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent extends UnSubscribable {

  loginData: LoginModel;
  errors: string[];

  constructor(
    private router: Router,
    private loginService: LoginService,
    private errorService: ErrorService,
    private textConstantService: TextConstantService
  ) {
    super();
    this.loginData = new LoginModel();
  }

  login( ) {
    this.errorService.clearErrors();

    this.loginService
      .login(this.loginData)
      .pipe(takeUntil(this.compUnsubscribe$))
      .subscribe(isAuthorized => {
        if (isAuthorized) {
          this.router.navigate(['home']);
        } else {
          this.errorService.showError(this.textConstantService.LOGIN_FAILED);
        }
      });
  }
}
