import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  errors$ = new Subject<string[]>();
  success$ = new Subject<string[]>();
  private errors: string[];
  private success: string[];

  constructor() { }

  showError(error: string) {
    this.errors.push(error);
    this.errors$.next(this.errors);
  }

  showSuccess(success: string) {
    this.success.push(success);
    this.success$.next(this.success);
  }

  clearErrors() {
    this.errors = [];
    this.errors$.next(this.errors);
  }

  clearSuccess() {
    this.success = [];
    this.success$.next(this.success);
  }

  clearAll() {
    this.clearErrors();
    this.clearSuccess();
  }
}
