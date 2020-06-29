import { takeUntil } from 'rxjs/operators';
import { UnSubscribable } from './../../../base-classes/unsubscribable';
import { ExamService } from './../../../services/exam.service';
import { Component, OnInit } from '@angular/core';
import { ExamModel } from 'src/app/models/exam.model';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-teacher-exam-overview',
  templateUrl: './teacher-exam-overview.component.html',
  styleUrls: ['./teacher-exam-overview.component.css']
})
export class TeacherExamOverviewComponent extends UnSubscribable implements OnInit {

  exams: ExamModel[];

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private examService: ExamService
  ) {
    super();
  }

  navigateBack() {
    this.location.back();
  }

  ngOnInit() {
    const classId = +this.route.snapshot.paramMap.get('classId');

    this.examService
      .getExamsForTeacher(classId)
      .pipe(takeUntil(this.compUnsubscribe$))
      .subscribe((e: ExamModel[]) => this.exams = e);
  }
}
