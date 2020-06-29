import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ClassModel } from '../models/class.model';

@Injectable({
  providedIn: 'root'
})
export class ClassService {

  private baseUrl = 'api/class/';

  constructor(private httpClient: HttpClient) { }

  getClassesOfTeacher(teacherId: number): Observable<ClassModel[]> {
    return this.httpClient.get<ClassModel[]>(`${this.baseUrl}teacher/${teacherId}`);
  }
}
