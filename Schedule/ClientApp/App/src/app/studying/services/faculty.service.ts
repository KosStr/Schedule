import { Injectable } from '@angular/core';
import { AuthHttpService } from 'src/app/core/services/auth-http.service';
import { Guid } from 'guid-typescript/dist/guid';
import { Observable } from 'rxjs';
import { FacultyDto } from '../models/FacultyDto';
import { FacultyApi } from '../api/api.faculty';

@Injectable()
export class FacultyService {
  constructor(
    private authHttp: AuthHttpService,
    private facultyApi: FacultyApi
  ) {}

  getFaculty(facultyId: Guid): Observable<FacultyDto> {
    return this.authHttp.get(this.facultyApi.FACULTY(facultyId));
  }
}
