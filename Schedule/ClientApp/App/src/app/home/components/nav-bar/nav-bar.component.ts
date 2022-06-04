import { Notification } from './../../dialogs/models/Notification';
import { NotificationDialogService } from './../../dialogs/services/notification-dialog.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';
import { CurrentUserService } from 'src/app/core/services/current-user.service';
import { AuthenticationService } from 'src/app/login/services/authentication.service';
import { UserService } from 'src/app/studying/services/user-service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit, OnDestroy {
  firstName = '';
  lastName = '';
  groupName = '';
  showNotifications = true;
  notificationsCount: number;
  destroy$ = new Subject<boolean>();

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private currentUserService: CurrentUserService,
    private userService: UserService,
    private notificationDialogService: NotificationDialogService
  ) {}

  ngOnInit(): void {
    this.getCurrentUser();
    this.getNotificationsCount();
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }

  public redirectHome(): void {
    this.router.navigate(['/home']);
  }

  public refreshPage(): void {
    window.location.reload();
  }

  public openNotifications(): void {
    this.showNotifications = false;
    this.notificationDialogService.showNotifications();
  }

  public logout(): void {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }

  private getCurrentUser(): void {
    this.currentUserService.firstName$
      .pipe(
        tap((firstName: string) => {
          if (firstName?.length) {
            this.firstName = firstName;
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();

    this.currentUserService.lastname$
      .pipe(
        tap((lastName: string) => {
          if (lastName?.length) {
            this.lastName = lastName;
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();

    this.currentUserService.groupName$
      .pipe(
        tap((name: string) => {
          if (name?.length) {
            this.groupName = name;
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }

  private getNotificationsCount(): void {
    this.userService
      .getNotifications()
      .pipe(
        tap((notifications: Notification[]) => {
          if (notifications?.length) {
            this.notificationsCount = notifications.length;
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }
}
