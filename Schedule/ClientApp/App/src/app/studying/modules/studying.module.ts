import { FacultyService } from './../services/faculty.service';
import { FacultyApi } from './../api/api.faculty';
import { OrganizationService } from './../services/organization.service';
import { OrganizationApi } from './../api/api.organization';
import { GroupInfoComponent } from './../components/group-info/group-info.component';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from 'src/app/core/routing/app-routing.module';
import { CurrentUserService } from 'src/app/core/services/current-user.service';
import { AppointmentApi } from '../api/api.appointment';
import { GroupApi } from '../api/api.group';
import { UserApi } from '../api/api.user';
import { OngoingAppointmentsComponent } from '../components/ongoing-appointments/ongoing-appointments.component';
import { AppointmentService } from '../services/appointment-service';
import { GroupService } from '../services/group-service';
import { UserService } from '../services/user-service';

@NgModule({
  imports: [CommonModule, HttpClientModule, AppRoutingModule, MatTableModule],
  declarations: [OngoingAppointmentsComponent, GroupInfoComponent],
  providers: [
    CurrentUserService,
    OrganizationApi,
    OrganizationService,
    FacultyApi,
    FacultyService,
    GroupApi,
    GroupService,
    AppointmentApi,
    AppointmentService,
    UserApi,
    UserService,
  ],
  entryComponents: [],
  exports: [],
})
export class StudyingModule {}
