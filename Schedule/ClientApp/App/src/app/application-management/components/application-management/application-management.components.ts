import { ApplicationManagementService } from './../../services/application-management.service';
import { OrganizationService } from './../../../studying/services/organization.service';
import { OrganizationDto } from './../../../studying/models/OrganizationDto';
import { CurrentUserService } from 'src/app/core/services/current-user.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { FormControl, Validators } from '@angular/forms';
import { Observable, Subject } from 'rxjs';
import { startWith, tap, map, mergeMap, takeUntil } from 'rxjs/operators';
import { ToastrNotificationService } from '../../../home/services/notification.service';
import { Guid } from 'guid-typescript/dist/guid';
import { User } from 'src/app/core/models/User';
import { Role } from 'src/app/core/enums/role.enum';

@Component({
  selector: 'application-management',
  templateUrl: './application-management.component.html',
  styleUrls: ['./application-management.component.css'],
})
export class ApplicationManagementComponent implements OnInit, OnDestroy {
  destroy$ = new Subject<boolean>();
  currentOrganization: OrganizationDto;
  students: User[] = [];

  constructor(
    private router: Router,
    private applicationManagementService: ApplicationManagementService,
    private toastrNotificationService: ToastrNotificationService,
    private currentUserService: CurrentUserService,
    private organizationService: OrganizationService,
    title: Title
  ) {
    title.setTitle('Schedule - Admin');
  }

  ngOnInit(): void {
    this.getOrganization();
    this.getFacultyMembers();
  }

  ngOnDestroy(): void {
    this.destroy$.next(false);
    this.destroy$.unsubscribe();
  }

  private getOrganization(): void {
    this.currentUserService.organizationId$
      .pipe(
        mergeMap((organizationId: Guid) => {
          return this.organizationService.getOrganization(organizationId);
        }),
        tap((organization: OrganizationDto) => {
          if (organization) {
            this.currentOrganization = organization;
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }

  private getFacultyMembers(): void {
    this.applicationManagementService
      .getUsersByFaculty()
      .pipe(
        tap((members: User[]) => {
          if (members?.length) {
            this.students = members.filter((i) => (i.role === Role.Student));
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }
}
