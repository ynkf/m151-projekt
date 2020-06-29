import { TextConstantService } from './../../../services/textConstant.service';
import { ErrorService } from './../../../services/error.service';
import { UnSubscribable } from './../../../base-classes/unsubscribable';
import { Component, OnInit } from '@angular/core';
import { StudentMarkModel } from 'src/app/models/student-mark.model';
import { ActivatedRoute } from '@angular/router';
import { ExamService } from 'src/app/services/exam.service';
import { Location } from '@angular/common';
import { takeUntil, catchError } from 'rxjs/operators';
import { isNil } from 'lodash';

@Component({
  selector: 'app-teacher-exam',
  templateUrl: './teacher-exam.component.html'
})
export class TeacherExamComponent extends UnSubscribable implements OnInit {

  students: StudentMarkModel[];

  private examId: number;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private examService: ExamService,
    private errorService: ErrorService,
    private textConstantService: TextConstantService
  ) {
    super();
  }

  save() {
    this.errorService.clearAll();

    this.examService
      .updateMarks(this.examId, this.students)
      .pipe(takeUntil(this.compUnsubscribe$))
      .pipe(catchError(err => {
        this.errorService.showError(`${this.textConstantService.UNABLE_TO_SAVE_MARKS} ERROR:${err}`);
        return [];
      }))
      .subscribe(res => {
        if (!isNil(res)) {
          this.errorService.showSuccess(`${this.textConstantService.SUCCESSFULLY_SAVED_MARKS}`);
        }
      });
  }

  navigateBack() {
    this.location.back();
  }

  ngOnInit() {
    this.examId = +this.route.snapshot.paramMap.get('examId');

    this.examService
      .getExamForTeacher(this.examId)
      .pipe(takeUntil(this.compUnsubscribe$))
      .subscribe((s: StudentMarkModel[]) => this.students = s);
  }
}
