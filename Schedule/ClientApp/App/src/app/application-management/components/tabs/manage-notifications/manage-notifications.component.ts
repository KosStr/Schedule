import { UserDto } from './../../../../studying/models/UserDto';
import { takeUntil, tap } from 'rxjs/operators';
import { ActionStatus } from './../../../../core/enums/action-status.enum';
import { Notification } from './../../../../home/dialogs/models/Notification';
import { ApplicationManagementService } from './../../../services/application-management.service';
import { EnumModel } from '../../../../core/models/EnumModel';
import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NotificationPriority } from 'src/app/core/enums/notification-priority';
import { EnumHelperService } from 'src/app/core/helpers/enum.service';
import { Subject } from 'rxjs';
import { ToastrNotificationService } from 'src/app/home/services/notification.service';
import { Guid } from 'guid-typescript/dist/guid';
import { SharedAutocompleteConfiguration } from 'src/app/shared/components/shared-autocomplete/shared-autocomplete.configuration';

@Component({
  selector: 'manage-notifications',
  templateUrl: './manage-notifications.component.html',
  styleUrls: ['./manage-notifications.component.scss'],
})
export class ManageNotificationsComponent implements OnInit, OnDestroy {
  minDate = new Date();
  selectedId: Guid;
  selectedStudents: UserDto[];
  displayedColumns: string[] = ['message', 'fromDate', 'dueDate', 'priority'];
  facultyNotifications: Notification[] = [];
  notificationPriority = NotificationPriority;
  notificationForm = new FormGroup({
    fromDate: new FormControl('', [Validators.required]),
    dueDate: new FormControl('', [Validators.required]),
    message: new FormControl('', [Validators.required]),
    priority: new FormControl('', [Validators.required]),
    //type: new FormControl('', [Validators.required]),
  });

  configuration = new SharedAutocompleteConfiguration({
    fontSize: 14,
    multiple: true,
    displayMultiple: true,
    displayedProperties: ['firstName', 'lastName'],
    selectIcon: 'add_circle_outline',
    autocompletePlaceholder: 'Add student',
    panelWidth: 250,
    selectedBackground: 'rgb(188, 235, 227)',
  });

  @Input() studentsList = new Array<UserDto>();

  destroy$ = new Subject<boolean>();

  priorities = EnumHelperService.enumSelector(
    NotificationPriority
  ) as EnumModel[];

  constructor(
    private toastrNotificationService: ToastrNotificationService,
    private applicationManagementService: ApplicationManagementService
  ) {}

  ngOnInit() {
    this.getNotifications();
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }

  public selectNotification(notification: Notification): void {
    if (this.selectedId === notification.id) {
      this.cleanForm();
      return;
    }
    this.notificationForm.setValue({
      fromDate: notification.fromDate,
      dueDate: notification.dueDate,
      message: notification.message,
      priority: notification.priority,
    });
    this.selectedId = notification.id;
  }

  public manageNotification(): void {
    if (this.notificationForm.invalid) {
      return;
    }

    if (
      !this.validateData(
        this.notificationForm.controls.fromDate.value,
        this.notificationForm.controls.dueDate.value
      )
    ) {
      return;
    }

    if (!this.selectedId) {
      this.applicationManagementService
        .createNotification(
          new Notification({
            ...this.notificationForm.value,
            type: 1,
            users: this.selectedStudents,
          })
        )
        .pipe(
          tap((result: ActionStatus) => this.handleResult(result)),
          takeUntil(this.destroy$)
        )
        .subscribe();
      this.cleanForm();
      return;
    } else {
      this.applicationManagementService
        .updateNotification(new Notification({}))
        .pipe(
          tap((result: ActionStatus) => {
            this.handleResult(result);
          }),
          takeUntil(this.destroy$)
        )
        .subscribe();
    }
  }

  public addStudents(students: Object[]): void {
    this.selectedStudents = students as UserDto[];
  }

  public deleteNotification(): void {
    this.applicationManagementService
      .deleteNotification(this.selectedId)
      .pipe(
        tap((result) => {
          if (result) {
            this.handleResult(result as ActionStatus);
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }

  private getNotifications(): void {
    this.applicationManagementService
      .getNotificationsByFacultyId()
      .pipe(
        tap((notifications: Notification[]) => {
          if (notifications?.length) {
            this.facultyNotifications = notifications;
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }

  private validateData(fromDate: Date, dueDate: Date): boolean {
    if (Date.parse(fromDate.toString()) >= Date.parse(dueDate.toString())) {
      this.toastrNotificationService.showErrorMessage('Incorrect date input');
      return false;
    }
    return true;
  }

  private handleResult(result: ActionStatus): void {
    result
      ? this.toastrNotificationService.showSuccessMessage(
          'Operation successful'
        )
      : this.toastrNotificationService.showErrorMessage('Incorrect input');
  }

  private cleanForm(): void {
    this.selectedId = null;
    this.notificationForm.reset();
  }
}
