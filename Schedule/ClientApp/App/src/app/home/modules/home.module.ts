import {NgModule} from "@angular/core";
import {ToastrModule} from "ngx-toastr";
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {CommonModule} from "@angular/common";
import { HomeComponent } from '../components/home/home.component';
import {NavBarComponent} from "../components/nav-bar/nav-bar.component";
import {RouterModule} from "@angular/router";
import {FooterComponent} from "../components/footer/footer.component";
import {NotificationService} from "../services/notification.service";

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot({
      progressBar: true,
      closeButton: true
    }),
    RouterModule,
  ],
  declarations: [
    HomeComponent,
    NavBarComponent,
    FooterComponent
  ],
  providers: [
    NotificationService
  ],
  entryComponents: []
})
export class HomeModule {}
