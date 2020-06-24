import { ErrorService } from './../../services/error.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html'
})
export class ErrorComponent implements OnInit {

  errors: string[];

  constructor(private errorService: ErrorService) { }

  ngOnInit() {
    this.errorService.errors$.subscribe(errors => this.errors = errors);
  }
}
