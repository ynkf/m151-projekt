import { StudentExamModel } from './../../../models/student-exam.model';
import { takeUntil } from 'rxjs/operators';
import { LoginService } from './../../../services/login.service';
import { ExamService } from 'src/app/services/exam.service';
import { UnSubscribable } from './../../../base-classes/unsubscribable';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-student-exams',
  templateUrl: './student-exams.component.html'
})
export class StudentExamsComponent extends UnSubscribable implements OnInit {

  studentExams: StudentExamModel[];

  constructor(
    private examService: ExamService,
    private loginService: LoginService
  ) {
    super();
  }

  ngOnInit() {
    this.examService
      .getStudentExams(this.loginService.currentUser.id)
      .pipe(takeUntil(this.compUnsubscribe$))
      .subscribe(se => this.studentExams = se);
  }
}
