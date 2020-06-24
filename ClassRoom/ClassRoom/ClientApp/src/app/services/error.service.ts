import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  errors$ = new Subject<string[]>();
  private errors: string[];

  constructor() { }

  showError(error: string) {
    this.errors.push(error);
    this.errors$.next(this.errors);
  }

  clearErrors() {
    this.errors = [];
    this.errors$.next(this.errors);
  }
}
