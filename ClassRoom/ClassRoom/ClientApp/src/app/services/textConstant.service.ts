import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TextConstantService {

  public readonly LOGIN_FAILED = 'Login fehlgeschalgen, überprüfen Sie Ihre Angaben.';

  constructor() { }
}
