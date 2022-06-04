import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Guid } from "guid-typescript/dist/guid";
import { Observable } from "rxjs";
import { AuthHttpService } from "src/app/core/services/auth-http.service";
import { AppointmentApi } from "../api/api.appointment";

@Injectable()
export class AppointmentService {

  constructor(
    private http: HttpClient,
    private authHttp: AuthHttpService,
    private appointmentApi: AppointmentApi
  ) {
  }

  // getAppointments(groupId: Guid): Observable<Object> {
  //   return this.http.get(this.appointmentApi);
  // }
}
