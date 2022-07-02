import { GroupDto } from 'src/app/studying/models/GroupDto';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SharedAutocompleteConfiguration } from 'src/app/shared/components/shared-autocomplete/shared-autocomplete.configuration';
import { Guid } from 'guid-typescript/dist/guid';
import { UserDto } from 'src/app/studying/models/UserDto';
import { Subject } from 'rxjs';
import { ToastrNotificationService } from 'src/app/home/services/notification.service';
import { ApplicationManagementService } from 'src/app/application-management/services/application-management.service';
import { ActionStatus } from 'src/app/core/enums/action-status.enum';
import { takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'manage-groups',
  templateUrl: './manage-groups.component.html',
  styleUrls: ['./manage-groups.component.scss'],
})
export class ManageGroupsComponent implements OnInit {
  selectedId: Guid;
  selectedStudents: UserDto[];
  displayedColumns: string[] = ['name', 'membersCount'];
  facultyGroups: GroupDto[] = [];
  groupForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
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

  constructor(
    private toastrNotificationService: ToastrNotificationService,
    private applicationManagementService: ApplicationManagementService
  ) {}

  ngOnInit() {
    this.getGroups();
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }

  public selectGroup(group: GroupDto): void {
    if (this.selectedId === group.id) {
      this.cleanForm();
      return;
    }
    this.groupForm.setValue({
      name: group.name,
    });
    this.selectedStudents = group.users;
    this.selectedId = group.id;
  }

  public manageGroup(): void {
    if (this.groupForm.invalid) {
      return;
    }

    if (!this.selectedId) {
      // this.applicationManagementService
      //   .createNotification(
      //     new Notification({
      //       ...this.notificationForm.value,
      //       type: 1,
      //       users: this.selectedStudents,
      //     })
      //   )
      //   .pipe(
      //     tap((result: ActionStatus) => this.handleResult(result)),
      //     takeUntil(this.destroy$)
      //   )
      //   .subscribe();
      // this.cleanForm();
      // return;
    } else {
      // this.applicationManagementService
      //   .updateNotification(new Notification({}))
      //   .pipe(
      //     tap((result: ActionStatus) => {
      //       this.handleResult(result);
      //     }),
      //     takeUntil(this.destroy$)
      //   )
      //   .subscribe();
    }
  }

  public addStudents(students: Object[]): void {
    this.selectedStudents = students as UserDto[];
  }

  public deleteGroup(): void {
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

  private getGroups(): void {
    this.applicationManagementService
      .getGroupsByFacultyId()
      .pipe(
        tap((groups: GroupDto[]) => {
          if (groups?.length) {
            this.setMembersCount(groups);
            this.facultyGroups = groups;
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
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
    this.groupForm.reset();
  }

  private setMembersCount(groups: GroupDto[]): void {
    groups.forEach((i) => (i.membersCount = i.users?.length));
  }
}
