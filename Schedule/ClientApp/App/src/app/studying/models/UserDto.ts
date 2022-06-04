import { Guid } from 'guid-typescript/dist/guid';
import { Role } from 'src/app/core/enums/role.enum';

export class UserDto {
  id: Guid;
  email: string;
  firstName: string;
  lastName: string;
  phine: string;
  role: Role;

  constructor(model: Partial<UserDto>) {}
}
