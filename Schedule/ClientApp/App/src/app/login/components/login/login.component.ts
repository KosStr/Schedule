import { Component, OnDestroy } from '@angular/core';
import { AuthenticationService } from "../../services/authentication.service";
import { AuthDto } from "../../models/AuthDto";
import { Router } from "@angular/router";
import { Subject } from "rxjs";
import { ToastrNotificationService } from "../../../home/services/notification.service";
import { takeUntil, tap } from "rxjs/operators";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../common.css', './login.component.css']
})
export class LoginComponent implements OnDestroy {
  model: AuthDto = new AuthDto();
  passwordsShown = false;
  destroy$ = new Subject<boolean>();

  constructor(private router: Router,
    private authenticationService: AuthenticationService,
    private toastrNotificationService: ToastrNotificationService) { }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }

  public login(): void {
    this.authenticationService.login(this.model).pipe(
      tap((result: boolean) => {
        if (result) {
          this.toastrNotificationService.showSuccessMessage("Authentication has been success")
          this.router.navigate(['/']);
        } else {
          this.toastrNotificationService.showErrorMessage("Credentials has been rejected");
        }
      }, err => {
        this.toastrNotificationService.showErrorMessage(err);
      }),
      takeUntil(this.destroy$)
    )
      .subscribe();
  }

  public togglePasswordVisibility(): void {
    this.passwordsShown = !this.passwordsShown;
  }
}
