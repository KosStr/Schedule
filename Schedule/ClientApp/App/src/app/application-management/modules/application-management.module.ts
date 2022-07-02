import { SharedModule } from './../../shared/modules/shared.module';
import { NotificationApi } from 'src/app/studying/api/api.notification';
import { ManageNotificationsComponent } from './../components/tabs/manage-notifications/manage-notifications.component';
import { AppointmentApi } from './../../studying/api/api.appointment';
import { GroupApi } from './../../studying/api/api.group';
import { UserApi } from './../../studying/api/api.user';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatListModule } from '@angular/material/list';
import { MatRadioModule } from '@angular/material/radio';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTabsModule } from '@angular/material/tabs';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatSelectModule } from '@angular/material/select';
import { ApplicationManagementService } from '../services/application-management.service';
import { ApplicationManagementComponent } from '../components/application-management/application-management.components';
import { MatNativeDateModule } from '@angular/material/core';
import { ManageGroupsComponent } from '../components/tabs/manage-groups/manage-groups.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatTableModule,
    MatTabsModule,
    MatIconModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatDatepickerModule,
    MatRadioModule,
    MatPaginatorModule,
    MatSlideToggleModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatAutocompleteModule,
    MatListModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatAutocompleteModule,
    DragDropModule,
    SharedModule,
  ],
  declarations: [
    ApplicationManagementComponent,
    ManageNotificationsComponent,
    ManageGroupsComponent,
  ],
  providers: [
    ApplicationManagementService,
    UserApi,
    NotificationApi,
    GroupApi,
    AppointmentApi,
  ],
  entryComponents: [],
})
export class ApplicationManagementModule {}
