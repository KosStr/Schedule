import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import { Observable } from 'rxjs';
import {CurrentUserService} from "../services/current-user.service";

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(private router: Router,
              private currentUserService: CurrentUserService) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (this.currentUserService.isUserAuthenticated()) {
      return true;
    }

    this.router.navigate(['/login']);
    return false;
  }
}
