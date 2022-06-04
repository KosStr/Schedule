import { ApplicationManagementModule } from './../../application-management/modules/application-management.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppComponent } from '../components/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from '../../shared/modules/shared.module';
import { HomeModule } from '../../home/modules/home.module';
import { ToastrModule } from 'ngx-toastr';
import { LoginModule } from '../../login/modules/login.module';
import { AppRoutingModule } from '../routing/app-routing.module';
import { OverlayModule } from '../../overlay/modules/overlay.module';
import { HttpRequestsInterceptor } from '../interceptors/http-requests.interceptor';
import { CurrentUserService } from '../services/current-user.service';
import { AuthHttpService } from '../services/auth-http.service';
import { StudyingModule } from 'src/app/studying/modules/studying.module';
import { DialogService } from '../dialogs/services/dialog.service';
import { DialogModule } from './dialog.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ToastrModule.forRoot({
      progressBar: true,
      closeButton: true,
    }),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    LoginModule,
    SharedModule,
    HomeModule,
    OverlayModule,
    StudyingModule,
    DialogModule,
    ApplicationManagementModule,
    SharedModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpRequestsInterceptor,
      multi: true,
    },
    CurrentUserService,
    AuthHttpService,
    DialogService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
