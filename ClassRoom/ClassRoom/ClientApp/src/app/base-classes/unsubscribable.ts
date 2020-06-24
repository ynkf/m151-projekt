import { Subject } from 'rxjs';
import { OnDestroy } from '@angular/core';

export class UnSubscribable implements OnDestroy {

  compUnsubscribe$: Subject<void>;

  constructor() {
    this.compUnsubscribe$ = new Subject<void>();
  }

  protected unsubscribeAll() {
    this.compUnsubscribe$.next();
    this.compUnsubscribe$.complete();
  }

  ngOnDestroy(): void {
    this.unsubscribeAll();
  }
}
