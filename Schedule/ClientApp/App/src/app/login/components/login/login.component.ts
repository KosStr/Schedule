import {Component, OnDestroy, OnInit} from '@angular/core';
import {AuthenticationService} from "../../services/authentication.service";
import {AuthDto} from "../../models/AuthDto";
import {Router} from "@angular/router";
import {BehaviorSubject, Subject} from "rxjs";
import {NotificationService} from "../../../home/services/notification.service";
import {takeUntil} from "rxjs/operators";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../common.css', './login.component.css']
})
export class LoginComponent implements OnDestroy {
  model: AuthDto = new AuthDto();
  passwordsShown = false;
  destroy$ = new Subject<number>();

  constructor(private router: Router,
              private authenticationService: AuthenticationService,
              private notificationService: NotificationService) { }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }

  public login(): void {
    this.authenticationService.login(this.model)
      .pipe(
        takeUntil(this.destroy$)
      )
      .subscribe((result: boolean) => {
        if (result) {
          this.notificationService.showSuccessMessage("Authentication has been success")
          this.router.navigate(['/']);
        } else {
          this.notificationService.showErrorMessage("Credentials has been rejected");
        }
      }, err => {
        this.notificationService.showErrorMessage(err);
      });
  }

  public togglePasswordVisibility = (): void => {
    this.passwordsShown = !this.passwordsShown;
  }
}
