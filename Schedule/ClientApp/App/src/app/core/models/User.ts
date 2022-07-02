import {Guid} from "guid-typescript/dist/guid";
import {Role} from "../enums/role.enum";

export class User {
  id: Guid;
  firstName: string;
  lastName: string;
  groupName: string;
  groupId?: Guid;
  email: string;
  phone: string;
  role: Role;
  facultyId?: Guid;
  organizationId?: Guid;

  constructor(user: Partial<User>) {
    this.id = user.id;
    this.firstName = user.firstName;
    this.lastName = user.lastName;
    this.groupName = user.groupName;
    this.groupId = user.groupId;
    this.email = user.email;
    this.phone = user.phone;
    this.role = user.role;
    this.facultyId = user.facultyId;
    this.organizationId = user.organizationId;
  }
}
