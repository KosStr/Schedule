import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

const URL = `${environment.apiUrl}user/`;

@Injectable()
export class UserApi {
    APPOINTMENTS = `${URL}appointments`;
    MEMBERS = `${URL}members`;
    NOTIFICATIONS = `${URL}notifications`
    CHATS = `${URL}chats`;
}
