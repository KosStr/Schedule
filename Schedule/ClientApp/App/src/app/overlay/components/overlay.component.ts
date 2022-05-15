import {Component, OnDestroy, OnInit} from '@angular/core';
import {ReplaySubject} from "rxjs";
import {OverlayService} from "../services/overlay.service";
import {takeUntil, tap} from "rxjs/operators";

@Component({
  selector: 'app-overlay',
  templateUrl: './overlay.component.html',
  styleUrls: ['./overlay.component.css']
})
export class OverlayComponent implements OnDestroy {
  isBusy = false;
  destroy$ = new ReplaySubject(1);

  constructor(overlayService: OverlayService) {
    overlayService.isBusy$
      .pipe(
        tap((value: boolean) => {
          setTimeout(() => (this.isBusy = value));
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }
}
