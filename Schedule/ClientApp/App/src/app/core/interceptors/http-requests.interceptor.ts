import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor, HttpErrorResponse
} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {OverlayService} from "../../overlay/services/overlay.service";
import {NotificationService} from "../../home/services/notification.service";
import {catchError, finalize} from "rxjs/operators";
import {AuthenticationService} from "../../login/services/authentication.service";
import {TokenUpdateDto} from "../../login/models/TokenUpdateDto";
import {CurrentUserService} from "../services/current-user.service";

@Injectable()
export class HttpRequestsInterceptor implements HttpInterceptor {
  private count = 0;
  private isEnabled: boolean = false;
  private accessToken: string;

  constructor(private overlayService: OverlayService,
              private notificationService: NotificationService,
              private authService: AuthenticationService,
              private currentUserService: CurrentUserService) {
    overlayService.isEnabled$.subscribe((value: boolean) => {
      this.isEnabled = value;
    });
    currentUserService.accessToken$.subscribe((value: string) => {
      this.accessToken = value;
    });
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.isEnabled) {
      this.count++;
      this.overlayService.setBusy(true);
    }
    this.overlayService.setLoaderEnabled(true);
    return next.handle(request).pipe(
      finalize(() => {
        if (this.count) {
          this.count--;
        }
        if (!this.count) {
          this.overlayService.setBusy(false);
        }
      }),
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          this.authService.refresh(new TokenUpdateDto({ accessToken: this.accessToken }))
            .subscribe((response: boolean) => {
              if (response) {
                location.reload();
              } else {
                location.href = '/login';
              }
            });
        }
        if (error.status === 400) {
          this.notificationService.showErrorMessage(
            'The server cannot or will not process the request due to something that is perceived to be a client error.'
          );
        }
        return throwError(error);
      })
    )
  }
}
