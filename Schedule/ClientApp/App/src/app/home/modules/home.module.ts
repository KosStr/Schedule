import { ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { HelpDialogService } from './../dialogs/services/help-dialog.service';
import { HelpDialogComponent } from './../dialogs/components/help-dialog/help-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { NotificationDialogService } from './../dialogs/services/notification-dialog.service';
import { NotificationDialogComponent } from '../dialogs/components/notification-dialog/notification-dialog.component';
import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { HomeComponent } from '../components/home/home.component';
import { NavBarComponent } from '../components/nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { FooterComponent } from '../components/footer/footer.component';
import { ToastrNotificationService } from '../services/notification.service';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NavBarUserMenuComponent } from '../components/nav-bar/nav-bar-user-menu/nav-bar-user-menu.component';
import { MatBadgeModule } from '@angular/material/badge';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    ToastrModule.forRoot({
      progressBar: true,
      closeButton: true,
    }),
    MatIconModule,
    MatMenuModule,
    MatDialogModule,
    MatInputModule,
    MatFormFieldModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    MatBadgeModule,
  ],
  declarations: [
    HomeComponent,
    NavBarComponent,
    NavBarUserMenuComponent,
    FooterComponent,
    NotificationDialogComponent,
    HelpDialogComponent,
  ],
  providers: [
    ToastrNotificationService,
    NotificationDialogService,
    HelpDialogService,
  ],
  entryComponents: [NotificationDialogComponent, HelpDialogComponent],
})
export class HomeModule {}
