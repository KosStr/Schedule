import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NotificationDialogComponent } from '../components/notification-dialog/notification-dialog.component';

@Injectable()
export class NotificationDialogService {
  constructor(protected dialog: MatDialog) { }

  showNotifications() {
    const dialogRef = this.dialog.open(NotificationDialogComponent, {
      height: '470px',
      width: '500px',
      position: {top: '70px', right: '50px'}
    });
  }
}
