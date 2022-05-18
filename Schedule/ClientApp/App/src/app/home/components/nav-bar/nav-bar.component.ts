import { Component, OnDestroy, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Subject } from "rxjs";
import { CurrentUserService } from "src/app/core/services/current-user.service";
import { AuthenticationService } from "src/app/login/services/authentication.service";

@Component({
  selector: "app-nav-bar",
  templateUrl: "./nav-bar.component.html",
  styleUrls: ["./nav-bar.component.scss"],
})
export class NavBarComponent implements OnInit, OnDestroy {

  destroy$ = new Subject<boolean>();

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private currentUserService: CurrentUserService,
  ) {
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }

  public refreshPage(): void {
    window.location.reload();
  }

  public logout(): void {
    this.authenticationService.logout();
    this.router.navigate(["/login"]);
  }

  private getCurrentUser(): void {  }
}
