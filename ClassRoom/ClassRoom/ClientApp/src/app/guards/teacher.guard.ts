import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { LoginService } from '../services/login.service';

@Injectable({
  providedIn: 'root'
})
export class TeacherGuard implements CanActivate {

  constructor(
    private router: Router,
    private loginService: LoginService
  ) {}

  canActivate(): boolean {
    const res = this.loginService.isTeacher();

    if (!res) {
      this.router.navigate(['']);
    }

    return res;
  }
}
