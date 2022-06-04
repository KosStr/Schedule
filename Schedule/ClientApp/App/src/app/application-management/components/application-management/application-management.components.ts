import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { ApplicationManagementService } from '../../../application-management/services/application-management.service';
import { FormControl, Validators } from '@angular/forms';
import { Observable, Subject } from 'rxjs';
import { startWith, map, takeUntil } from 'rxjs/operators';
import { NotificationService } from '../../../home/services/notification.service';
import { CurrentUserService } from 'src/app/core/services/current-user.service';

@Component({
  selector: 'application-management',
  templateUrl: './application-management.component.html',
  styleUrls: ['./application-management.component.css'],
})
export class ApplicationManagementComponent implements OnInit, OnDestroy {
  destroy$ = new Subject<boolean>();

  constructor(
    private router: Router,
    private applicationService: ApplicationManagementService,
    private notificationService: NotificationService,
    currentUserService: CurrentUserService,
    title: Title
  ) {
    title.setTitle('Enquirya - SA');
  }

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.destroy$.next(false);
    this.destroy$.unsubscribe();
  }

  back(): void {
    this.router.navigate(['/home']);
  }
}
