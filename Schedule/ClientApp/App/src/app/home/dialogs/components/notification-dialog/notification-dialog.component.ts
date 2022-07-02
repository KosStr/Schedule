import { Notification } from '../../models/Notification';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { UserService } from '../../../../studying/services/user-service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import _ from 'lodash';
import { NotificationPriority } from 'src/app/core/enums/notification-priority';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'notification-dialog',
  templateUrl: 'notification-dialog.component.html',
  styleUrls: ['notification-dialog.component.css'],
})
export class NotificationDialogComponent implements OnInit, OnDestroy {
  notifications: Notification[] = [];
  notificationPriority = NotificationPriority;
  destroy$ = new Subject<boolean>();

  constructor(
    public dialogRef: MatDialogRef<NotificationDialogComponent>,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.getNotifications();
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }

  public closeDialog(): void {
    this.dialogRef.close();
  }

  private setColor(notification: Notification): void {
    switch (this.notificationPriority[notification.priority]) {
      case this.notificationPriority[NotificationPriority.High]:
        notification.color = 'indianred';
        break;
      case this.notificationPriority[NotificationPriority.Medium]:
        notification.color = 'orange';
        break
      case this.notificationPriority[NotificationPriority.Low]:
        notification.color = '#79bf79';
        break;
    }
  }

  private getNotifications(): void {
    this.userService
      .getNotifications()
      .pipe(
        tap((notifications: Notification[]) => {
          if (notifications?.length) {
            notifications.forEach((n: Notification) => this.setColor(n));
            this.notifications = notifications;
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }
}
