import { UserModel, UserTypes } from './../../models/user.model';
import { LoginService } from './../../services/login.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  isExpanded = false;

  constructor(
    private router: Router,
    private loginService: LoginService
  ) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  isStudent(): boolean {
    return this.loginService.isStudent();
  }

  isTeacher(): boolean {
    return this.loginService.isTeacher();
  }

  getCurrentUser(): UserModel {
    return this.loginService.currentUser;
  }

  logout() {
    this.loginService.logout();
  }

  navigate() {
    let route = '';

    if (this.loginService.currentUser) {
      switch (this.loginService.currentUser.userType) {
        case UserTypes.Student:
          route = 'student';
          break;
        case UserTypes.Teacher:
          route = 'teacher';
          break;
        default:
          break;
    }}

    this.router.navigate([route]);
  }
}
