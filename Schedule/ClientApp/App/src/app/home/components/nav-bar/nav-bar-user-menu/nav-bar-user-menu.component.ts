import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';
import { Role } from 'src/app/core/enums/role.enum';
import { CurrentUserService } from 'src/app/core/services/current-user.service';
import { HelpDialogService } from 'src/app/home/dialogs/services/help-dialog.service';

@Component({
  selector: 'app-nav-bar-user-menu',
  templateUrl: './nav-bar-user-menu.component.html',
  styleUrls: ['./nav-bar-user-menu.component.css'],
})
export class NavBarUserMenuComponent implements OnInit, OnDestroy {
  isAdmin = false;
  destroy$ = new Subject<boolean>();

  constructor(
    private currentUserService: CurrentUserService,
    private helpDialogService: HelpDialogService
  ) {}

  ngOnInit(): void {
    this.checkRole();
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }

  public showHelpDialog(): void {
    this.helpDialogService.showHelpDialog();
  }

  private checkRole(): void {
    this.currentUserService.role$
      .pipe(
        tap((role: Role) => {
          if (role === Role.Admin) {
            this.isAdmin = true;
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }
}
