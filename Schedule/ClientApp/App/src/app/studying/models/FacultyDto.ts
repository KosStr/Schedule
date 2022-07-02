import { Guid } from 'guid-typescript/dist/guid';
import { GroupDto } from './GroupDto';

export class FacultyDto {
  id: Guid;
  name: string;
  groups: GroupDto[];

  constructor(model: Partial<FacultyDto>) {
    this.id = model.id;
    this.name = model.name;
    this.groups = model.groups;
  }
}
