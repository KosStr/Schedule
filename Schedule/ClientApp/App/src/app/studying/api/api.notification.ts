import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript/dist/guid';
import { environment } from 'src/environments/environment';

const URL = `${environment.apiUrl}notification/`;

@Injectable()
export class NotificationApi {
  BASE = URL;

  NOTIFICATION(id: Guid): string {
    return `${URL}?id=${id}`;
  }

  DELETE_NOTIFICATION(id: Guid): string {
    return `${URL}delete/${id}`;
  }

  GET_NOTIFICATIONS=`${URL}faculty`;
}
