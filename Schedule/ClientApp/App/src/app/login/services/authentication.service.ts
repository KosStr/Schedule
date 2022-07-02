import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenApi } from '../api/auth.api';
import { CurrentUserService } from '../../core/services/current-user.service';
import { SessionStorageItems } from '../../core/helpers/session-storage-items';
import { AuthHttpService } from '../../core/services/auth-http.service';
import { map } from 'rxjs/operators';
import { AuthDto } from '../models/AuthDto';
import { AuthenticationResponse } from '../models/AuthenticationResponse';
import { User } from '../../core/models/User';
import { RegisterDto } from '../models/RegisterDto';
import { ActionStatus } from '../../core/enums/action-status.enum';
import { TokenUpdateDto } from '../models/TokenUpdateDto';

@Injectable()
export class AuthenticationService {
  constructor(
    private tokenApi: TokenApi,
    private currentUserService: CurrentUserService,
    private authHttpService: AuthHttpService
  ) {
    const currentUser = JSON.parse(
      sessionStorage.getItem(SessionStorageItems.currentUser.toString())
    );
    if (!currentUser) {
      this.logout();
    }
  }

  public login(user: AuthDto): Observable<boolean> {
    return this.authHttpService.post(this.tokenApi.LOGIN_URL, user).pipe(
      map((response: AuthenticationResponse) => {
        return this.processAuthentication(response);
      })
    );
  }

  public register(user: RegisterDto): Observable<boolean> {
    return this.authHttpService.post(this.tokenApi.REGISTER_URL, user).pipe(
      map((response: any) => {
        return !!response;
      })
    );
  }

  public refresh(token: TokenUpdateDto): Observable<boolean> {
    return this.authHttpService.post(this.tokenApi.REFRESH_URL, token).pipe(
      map((response: AuthenticationResponse) => {
        return this.processAuthentication(response);
      })
    );
  }

  public setParams(model: { accessToken: string; user: User }): void {
    if (model.user) {
      this.currentUserService.setCurrentUser(model);
    }
  }

  public logout(): void {
    this.currentUserService.resetCurrentUser();
    sessionStorage.removeItem(SessionStorageItems.currentUser.toString());
  }

  private processAuthentication(authResponse: AuthenticationResponse): boolean {
    if (authResponse && authResponse.status === ActionStatus.Success) {
      sessionStorage.setItem(
        SessionStorageItems.currentUser.toString(),
        JSON.stringify({ ...authResponse })
      );
      this.currentUserService.setCurrentUser({ ...authResponse });
      return true;
    } else {
      return false;
    }
  }
}
