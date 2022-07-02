import { Guid } from 'guid-typescript/dist/guid';
import { AppointmentDto } from './AppiontmentDto';
import { UserDto } from './UserDto';

export class GroupDto {
  id: Guid;
  name: string;
  users = new Array<UserDto>();
  membersCount: number;
  appointments = new Array<AppointmentDto>();

  constructor(model: Partial<GroupDto>) {
    this.id = model.id;
    this.name = model.name;
    this.users = model.users;
    this.appointments = model.appointments;
    this.membersCount = model.membersCount;
  }
}
