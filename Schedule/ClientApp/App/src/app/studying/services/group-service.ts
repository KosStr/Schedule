import { Injectable } from "@angular/core";
import { Guid } from "guid-typescript/dist/guid";
import { Observable } from "rxjs";
import { AuthHttpService } from "src/app/core/services/auth-http.service";
import { GroupApi } from "../api/api.group";
import { GroupDto } from "../models/GroupDto";

@Injectable()
export class GroupService {

    constructor(
        private authHttp: AuthHttpService,
        private groupApi: GroupApi
    ) { }

    getGroup(groupId: Guid): Observable<GroupDto> {
        return this.authHttp.get(this.groupApi.GROUP(groupId));
    }
}
