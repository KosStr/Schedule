import { Guid } from 'guid-typescript/dist/guid';
import { FacultyDto } from './FacultyDto';

export class OrganizationDto {
  id: Guid;
  name: string;
  faculties: FacultyDto[];

  constructor(model: Partial<OrganizationDto>) {
    this.id = model.id;
    this.name = model.name;
    this.faculties = model.faculties;
  }
}
