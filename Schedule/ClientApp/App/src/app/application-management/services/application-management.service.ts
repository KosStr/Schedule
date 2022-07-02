import { ActionStatus } from './../../core/enums/action-status.enum';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript/dist/guid';
import { Observable } from 'rxjs';
import { AuthHttpService } from 'src/app/core/services/auth-http.service';
import { Notification } from 'src/app/home/dialogs/models/Notification';
import { AppointmentApi } from 'src/app/studying/api/api.appointment';
import { GroupApi } from 'src/app/studying/api/api.group';
import { NotificationApi } from 'src/app/studying/api/api.notification';
import { UserApi } from 'src/app/studying/api/api.user';
import { User } from 'src/app/core/models/User';
import { GroupDto } from 'src/app/studying/models/GroupDto';

@Injectable()
export class ApplicationManagementService {

  constructor(private authHttpService: AuthHttpService,
    private groupApi: GroupApi,
    private appointmentApi: AppointmentApi,
    private userApi: UserApi,
    private notificationApi: NotificationApi) { }

    createGroup(group: GroupDto):void{}
    updateGroup():void{}
    deleteGroup():void{}

    getGroupsByFacultyId(): Observable<GroupDto[]> {
      return this.authHttpService.get(this.groupApi.GET_GROUPS);
    }

    createNotification(notification: Notification): Observable<ActionStatus> {
      return this.authHttpService.post(this.notificationApi.BASE, notification);
    }

    updateNotification(notification: Notification): Observable<ActionStatus> {
      return this.authHttpService.put(this.notificationApi.BASE, notification);
    }

    getNotificationsByFacultyId(): Observable<Notification[]> {
      return this.authHttpService.get(this.notificationApi.GET_NOTIFICATIONS);
    }

    deleteNotification(id: Guid): Observable<Object> {
      return this.authHttpService.delete(this.notificationApi.DELETE_NOTIFICATION(id));
    }

    createAppointment():void{}
    updateAppointment():void{}
    deleteAppointment():void{}

    createSubject():void{}
    updateSubject():void{}
    deleteSubject():void{}

    createUser():void{}
    updateUser():void{}
    deleteUser():void{}

    getUsersByFaculty():Observable<User[]>{
      return this.authHttpService.get(this.userApi.FACULTY_MEMBERS);
    }
}
