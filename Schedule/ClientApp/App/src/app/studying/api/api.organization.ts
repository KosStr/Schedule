import { Injectable } from "@angular/core";
import { Guid } from "guid-typescript/dist/guid";
import { environment } from "src/environments/environment";

const URL = `${environment.apiUrl}organization/`;

@Injectable()
export class OrganizationApi {
    ORGANIZATION(id: Guid): string {
        return `${URL}?id=${id}`;
      }
}
