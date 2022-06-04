import {
  Component,
  OnChanges,
  OnDestroy,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';
import { CurrentUserService } from 'src/app/core/services/current-user.service';
import { AppointmentDto } from '../../models/AppiontmentDto';
import { AppointmentService } from '../../services/appointment-service';
import { UserService } from '../../services/user-service';

@Component({
  selector: 'ongoing-appointments-component',
  templateUrl: './ongoing-appointments.component.html',
  styleUrls: ['./ongoing-appointments.component.css'],
})
export class OngoingAppointmentsComponent
  implements OnChanges, OnInit, OnDestroy
{
  dataSource = new MatTableDataSource<Object>();
  destroy$ = new Subject<boolean>();
  tableColumnNames = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'];

  constructor(private router: Router, private userService: UserService) {}

  ngOnChanges(changes: SimpleChanges): void {}

  ngOnInit(): void {
    this.getAppointments();
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }

  private getAppointments(): void {
    this.userService
      .getAppointments()
      .pipe(
        tap((appointments: AppointmentDto[]) => {
          if (appointments?.length) {
            this.dataSource.data = appointments;
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }
}
