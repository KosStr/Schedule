import { Guid } from 'guid-typescript/dist/guid';
import { Role } from 'src/app/core/enums/role.enum';

export class UserDto {
  id: Guid;
  email: string;
  firstName: string;
  lastName: string;
  phone: string;
  role: Role;

  constructor(model: Partial<UserDto>) {
    this.id = model.id;
    this.email = model.email;
    this.firstName = model.firstName;
    this.lastName = model.lastName;
    this.phone = model.phone;
    this.role = model.role;
  }
}
