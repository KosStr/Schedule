import { Notification } from '../../home/dialogs/models/Notification';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthHttpService } from 'src/app/core/services/auth-http.service';
import { UserApi } from '../api/api.user';
import { AppointmentDto } from '../models/AppiontmentDto';
import { UserDto } from '../models/UserDto';

@Injectable()
export class UserService {
  constructor(private authHttp: AuthHttpService, private userApi: UserApi) {}

  getMembers(): Observable<UserDto[]> {
    return this.authHttp.get(this.userApi.MEMBERS);
  }

  getAppointments(): Observable<AppointmentDto[]> {
    return this.authHttp.get(this.userApi.APPOINTMENTS);
  }

  getNotifications(): Observable<Notification[]> {
    return this.authHttp.get(this.userApi.NOTIFICATIONS);
  }
}
