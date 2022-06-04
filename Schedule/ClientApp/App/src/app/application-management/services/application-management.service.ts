import { Injectable } from '@angular/core';
import { AuthHttpService } from 'src/app/core/services/auth-http.service';
import { AppointmentApi } from 'src/app/studying/api/api.appointment';
import { GroupApi } from 'src/app/studying/api/api.group';
import { UserApi } from 'src/app/studying/api/api.user';

@Injectable()
export class ApplicationManagementService {

  constructor(private authHttpService: AuthHttpService,
    private groupApi: GroupApi,
    private appointmentApi: AppointmentApi,
    private userApi: UserApi) { }

    addGroup():void{}
    editGroup():void{}
    deleteGroup():void{}

    addNotification():void{}
    editNotification():void{}
    deleteNotification():void{}

    addAppointment():void{}
    editAppointment():void{}
    deleteAppointment():void{}

    addSubject():void{}
    editSubject():void{}
    deleteSubject():void{}

    addUser():void{}
    editUser():void{}
    deleteUser():void{}
}
