import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {CurrentUserService} from "./current-user.service";
import {Observable} from "rxjs";

@Injectable()
export class AuthHttpService {
  token: string;

  constructor(private http: HttpClient, currentUserService: CurrentUserService) {
    currentUserService.accessToken$.subscribe((value: string) => {
      this.token = value;
    });
  }

  get(uri: string): Observable<any> {
    let headers = new HttpHeaders();
    headers = this.setAuthorizationHeader(headers);

    return this.http.get(uri, {
      headers: headers
    });
  }

  post(url, data): Observable<any> {
    let headers = new HttpHeaders();
    headers = this.setAuthorizationHeader(headers);

    return this.http.post(url, data, {
      headers
    });
  }

  put(url, data): Observable<any> {
    let headers = new HttpHeaders();
    headers = this.setAuthorizationHeader(headers);

    return this.http.put(url, data, {
      headers
    });
  }

  delete(uri: string) {
    let headers = new HttpHeaders();
    headers = this.setAuthorizationHeader(headers);

    return this.http.delete(uri, {
      headers,
    });
  }

  private setAuthorizationHeader(headers: HttpHeaders): HttpHeaders {
    return headers.set('Authorization', 'Bearer ' + this.token);
  }
}
