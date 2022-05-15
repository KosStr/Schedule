import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AuthGuard} from "../../core/guards/auth.guard";
import { LoginComponent } from '../components/login/login.component';
import {AuthenticationService} from "../services/authentication.service";
import {MatCardModule} from "@angular/material/card";
import {MatInputModule} from "@angular/material/input";
import {MatIconModule} from "@angular/material/icon";
import {FormsModule} from "@angular/forms";
import {MatButtonModule} from "@angular/material/button";
import {TokenApi} from "../api/auth.api";



@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    FormsModule,
    MatButtonModule
  ],
  providers: [
    AuthGuard,
    AuthenticationService,
    TokenApi
  ]
})
export class LoginModule { }
