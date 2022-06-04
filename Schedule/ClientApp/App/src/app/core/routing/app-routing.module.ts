import { GroupInfoComponent } from './../../studying/components/group-info/group-info.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../../home/components/home/home.component';
import { AuthGuard } from '../guards/auth.guard';
import { LoginComponent } from '../../login/components/login/login.component';
import { OngoingAppointmentsComponent } from 'src/app/studying/components/ongoing-appointments/ongoing-appointments.component';
import { ApplicationManagementComponent } from 'src/app/application-management/components/application-management/application-management.components';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'home',
        component: OngoingAppointmentsComponent,
      },
      {
        path: "admin",
        component: ApplicationManagementComponent,
      },
      {
        path: "group",
        component: GroupInfoComponent,
      },
      { path: '', redirectTo: 'home', pathMatch: 'full' },
    ],
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
