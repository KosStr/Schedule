import { OrganizationApi } from './../api/api.organization';
import { Injectable } from '@angular/core';
import { AuthHttpService } from 'src/app/core/services/auth-http.service';
import { Guid } from 'guid-typescript/dist/guid';
import { Observable } from 'rxjs';
import { OrganizationDto } from '../models/OrganizationDto';

@Injectable()
export class OrganizationService {
  constructor(
    private authHttp: AuthHttpService,
    private organizationApi: OrganizationApi
  ) {}

  getOrganization(organizationId: Guid): Observable<OrganizationDto> {
    return this.authHttp.get(this.organizationApi.ORGANIZATION(organizationId));
  }
}
