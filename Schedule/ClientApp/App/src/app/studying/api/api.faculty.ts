import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript/dist/guid';
import { environment } from 'src/environments/environment';

const URL = `${environment.apiUrl}faculty/`;

@Injectable()
export class FacultyApi {
  FACULTY(id: Guid): string {
    return `${URL}?id=${id}`;
  }
}
