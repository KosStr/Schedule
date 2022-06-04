import { Injectable } from "@angular/core";
import { Guid } from "guid-typescript/dist/guid";
import { environment } from "src/environments/environment";

const URL = `${environment.apiUrl}group/`;

@Injectable()
export class GroupApi {
    GROUP(id: Guid): string {
        return `${URL}?id=${id}`;
      }
}
