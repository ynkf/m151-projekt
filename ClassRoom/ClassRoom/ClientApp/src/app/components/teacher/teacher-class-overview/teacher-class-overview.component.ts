import { UnSubscribable } from './../../../base-classes/unsubscribable';
import { LoginService } from './../../../services/login.service';
import { ClassService } from './../../../services/class.service';
import { ClassModel } from './../../../models/class.model';
import { Component, OnInit, Input } from '@angular/core';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-teacher-class-overview',
  templateUrl: './teacher-class-overview.component.html'
})
export class TeacherClassOverviewComponent {

  @Input()
  classes: ClassModel[];
}
