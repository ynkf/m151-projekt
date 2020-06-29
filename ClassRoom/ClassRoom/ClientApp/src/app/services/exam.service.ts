import { StudentExamModel } from './../models/student-exam.model';
import { ExamModel } from 'src/app/models/exam.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StudentMarkModel } from '../models/student-mark.model';

@Injectable({
  providedIn: 'root'
})
export class ExamService {

  constructor(private httpClient: HttpClient) { }

  getExamsForTeacher(classId: number): Observable<ExamModel[]> {
    return this.httpClient.get<ExamModel[]>(`api/exam/teacher/class/${classId}`);
  }

  getExamForTeacher(examId: number): Observable<StudentMarkModel[]> {
    return this.httpClient.get<StudentMarkModel[]>(`api/exam/teacher/exam/${examId}`);
  }

  updateMarks(examId: number, studentMarkmodels: StudentMarkModel[]): Observable<any> {
    return this.httpClient.post(`api/exam/teacher/exam/${examId}`, studentMarkmodels);
  }

  getStudentExams(studentId: number): Observable<StudentExamModel[]> {
    return this.httpClient.get<StudentExamModel[]>(`api/exam/student/${studentId}`);
  }
}
