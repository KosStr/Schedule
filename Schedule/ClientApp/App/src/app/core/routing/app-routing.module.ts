import { NgModule } from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {HomeComponent} from "../../home/components/home/home.component";
import {AuthGuard} from "../guards/auth.guard";
import {LoginComponent} from "../../login/components/login/login.component";

const routes: Routes = [
  { path: "login", component: LoginComponent },
  {
    path: "",
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: "home",
        component: HomeComponent
      }
    ]
  },
  { path: "**", redirectTo: "" }
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
