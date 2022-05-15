import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable} from "rxjs";

@Injectable()
export class OverlayService {
  public isBusy$: Observable<boolean>;
  private isBusy: BehaviorSubject<boolean>;
  public isEnabled$: Observable<boolean>;
  private isEnabled: BehaviorSubject<boolean>;

  constructor() {
    this.isBusy = new BehaviorSubject<boolean>(false);
    this.isBusy$ = this.isBusy.asObservable();
    this.isEnabled = new BehaviorSubject<boolean>(true);
    this.isEnabled$ = this.isEnabled.asObservable();
  }

  setBusy(value: boolean) {
    this.isBusy.next(value);
  }

  setLoaderEnabled(value: boolean) {
    this.isEnabled.next(value);
  }
}
