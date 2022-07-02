import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Guid } from 'guid-typescript/dist/guid';
import { Role } from '../enums/role.enum';
import { SessionStorageItems } from '../helpers/session-storage-items';
import { User } from '../models/User';

@Injectable()
export class CurrentUserService {
  public accessToken$: Observable<string>;
  private accessToken: BehaviorSubject<string>;

  public firstName$: Observable<string>;
  private firstName: BehaviorSubject<string>;

  public lastname$: Observable<string>;
  private lastname: BehaviorSubject<string>;

  public userId$: Observable<Guid>;
  private userId: BehaviorSubject<Guid>;

  public email$: Observable<string>;
  private email: BehaviorSubject<string>;

  public role$: Observable<Role>;
  private role: BehaviorSubject<Role>;

  public groupName$: Observable<string>;
  private groupName: BehaviorSubject<string>;

  public groupId$: Observable<Guid>;
  private groupId: BehaviorSubject<Guid>;

  public facultyId$: Observable<Guid>;
  private facultyId: BehaviorSubject<Guid>;

  public organizationId$: Observable<Guid>;
  private organizationId: BehaviorSubject<Guid>;

  constructor() {
    this.accessToken = new BehaviorSubject<string>(null);
    this.accessToken$ = this.accessToken.asObservable();

    this.firstName = new BehaviorSubject<string>(null);
    this.firstName$ = this.firstName.asObservable();

    this.lastname = new BehaviorSubject<string>(null);
    this.lastname$ = this.lastname.asObservable();

    this.userId = new BehaviorSubject<Guid>(null);
    this.userId$ = this.userId.asObservable();

    this.role = new BehaviorSubject<Role>(null);
    this.role$ = this.role.asObservable();

    this.email = new BehaviorSubject<string>(null);
    this.email$ = this.email.asObservable();

    this.groupName = new BehaviorSubject<string>(null);
    this.groupName$ = this.groupName.asObservable();

    this.groupId = new BehaviorSubject<Guid>(null);
    this.groupId$ = this.groupId.asObservable();

    this.facultyId = new BehaviorSubject<Guid>(null);
    this.facultyId$ = this.facultyId.asObservable();

    this.organizationId = new BehaviorSubject<Guid>(null);
    this.organizationId$ = this.organizationId.asObservable();

    const currentUser = JSON.parse(
      sessionStorage.getItem(SessionStorageItems.currentUser.toString())
    );

    if (currentUser) {
      this.setCurrentUser({ ...currentUser });
    }
  }

  setCurrentUser(model: { accessToken: string; user: User }) {
    this.accessToken.next(model.accessToken);
    if (model.user) {
      this.firstName.next(model.user.firstName);
      this.lastname.next(model.user.lastName);
      this.role.next(model.user.role);
      this.userId.next(model.user.id);
      this.email.next(model.user.email);
      this.groupName.next(model.user.groupName);
      this.groupId.next(model.user.groupId);
      this.facultyId.next(model.user.facultyId);
      this.organizationId.next(model.user.organizationId);
    }
  }

  resetCurrentUser() {
    this.accessToken.next(null);
    this.role.next(null);
    this.userId.next(null);
    this.email.next(null);
    this.firstName.next(null);
    this.lastname.next(null);
    this.facultyId.next(null);
    this.organizationId.next(null);
  }

  isUserAuthenticated(): boolean {
    return this.accessToken.value !== null;
  }

  isRole(role: Role): boolean {
    return this.role.value === role;
  }

  hasAdminAccess(): boolean {
    return this.role.value === Role.Admin;
  }
}
