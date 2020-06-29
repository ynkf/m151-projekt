import { TeacherGuard } from './guards/teacher.guard';
import { StudentGuard } from './guards/student.guard';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { LoginComponent } from './components/login/login.component';
import { ErrorComponent } from './components/error/error.component';
import { TeacherExamsComponent } from './components/teacher/teacher-exams/teacher-exams.component';
import { StudentExamsComponent } from './components/student/student-exams/student-exams.component';
import { TeacherClassOverviewComponent } from './components/teacher/teacher-class-overview/teacher-class-overview.component';
import { TeacherExamOverviewComponent } from './components/teacher/teacher-exam-overview/teacher-exam-overview.component';
import { TeacherExamComponent } from './components/teacher/teacher-exam/teacher-exam.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    ErrorComponent,
    TeacherExamsComponent,
    StudentExamsComponent,
    TeacherClassOverviewComponent,
    TeacherExamOverviewComponent,
    TeacherExamComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'student', component: StudentExamsComponent, canActivate: [StudentGuard] },
      { path: 'teacher', component: TeacherExamsComponent, canActivate: [TeacherGuard]  },
      { path: 'teacher/class/:classId', component: TeacherExamOverviewComponent, canActivate: [TeacherGuard]  },
      { path: 'teacher/class/:classId/exam/:examId', component: TeacherExamComponent, canActivate: [TeacherGuard]  },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
