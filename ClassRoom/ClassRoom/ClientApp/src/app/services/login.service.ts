import { TextConstantService } from './textConstant.service';
import { ErrorService } from './error.service';
import { UserModel, UserTypes } from './../models/user.model';
import { LoginModel } from './../models/login.model';
import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { isNil } from 'lodash';
import { UnSubscribable } from '../base-classes/unsubscribable';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService
  extends UnSubscribable {

  currentUser: UserModel;

  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private errorService: ErrorService,
    private textConstantService: TextConstantService
    ) {
    super();
  }

  login(loginData: LoginModel) {
    this.errorService.clearErrors();

    return this.httpClient
      .post('api/user/login', loginData)
      .pipe(takeUntil(this.compUnsubscribe$))
      .subscribe((user: UserModel) => {
        if (isNil(user)) {
          this.errorService.showError(this.textConstantService.LOGIN_FAILED);
        } else if (user.userType === UserTypes.User) {
          this.errorService.showError(this.textConstantService.USER_TYPE_NOT_SET);
        } else {
          this.currentUser = user;

          this.navigate();
        }
      });
  }

  logout() {
    this.currentUser = null;
    this.router.navigate(['']);
  }

  isTeacher(): boolean {
    return !isNil(this.currentUser) && this.currentUser.userType === UserTypes.Teacher;
  }

  isStudent(): boolean {
    return !isNil(this.currentUser) && this.currentUser.userType === UserTypes.Student;
  }

  private navigate() {
    switch (this.currentUser && this.currentUser.userType) {
      case UserTypes.Student:
        this.router.navigate(['student']);
        break;
      case UserTypes.Teacher:
        this.router.navigate(['teacher']);
        break;
      default:
        this.logout();
        break;
    }
  }
}
