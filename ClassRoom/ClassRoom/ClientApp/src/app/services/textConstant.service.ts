import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TextConstantService {

  public readonly LOGIN_FAILED = 'Login fehlgeschalgen, überprüfen Sie Ihre Angaben.';
  public readonly USER_TYPE_NOT_SET = 'User wurde nicht als Lehrer oder Student gesetzt.';
  public readonly UNABLE_TO_LOAD_USER_DATA = 'Die Nutzerdaten konnten nicht geladen werden.';
  public readonly UNABLE_TO_SAVE_MARKS = 'Die Noten konnten nicht gespeichert werden.';
  public readonly SUCCESSFULLY_SAVED_MARKS = 'Die Noten konnten erfolgreich gespeichert werden.';

  constructor() { }
}
