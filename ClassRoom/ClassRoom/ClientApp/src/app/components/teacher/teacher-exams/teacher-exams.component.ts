import { UserModel, UserTypes } from './../../../models/user.model';
import { takeUntil } from 'rxjs/operators';
import { UnSubscribable } from './../../../base-classes/unsubscribable';
import { LoginService } from './../../../services/login.service';
import { Component, OnInit } from '@angular/core';
import { ClassModel } from 'src/app/models/class.model';
import { ClassService } from 'src/app/services/class.service';

@Component({
  selector: 'app-teacher-exams',
  templateUrl: './teacher-exams.component.html'
})
export class TeacherExamsComponent extends UnSubscribable implements OnInit {

  isNewExam = false;
  classes: ClassModel[];

  constructor(
    private classService: ClassService,
    private loginService: LoginService) { super(); }

  isTeacher(): boolean {
    return this.loginService.isTeacher();
  }

  ngOnInit( ) {
    if (this.loginService.currentUser) {
      this.classService
        .getClassesOfTeacher(this.loginService.currentUser.id)
        .pipe(takeUntil(this.compUnsubscribe$))
        .subscribe(c => {
          this.classes = c;
          console.log(this.classes);
        });
    }
  }
}
