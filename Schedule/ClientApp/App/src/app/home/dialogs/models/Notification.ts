import { Guid } from 'guid-typescript/dist/guid';
import { NotificationPriority } from 'src/app/core/enums/notification-priority';
import { UserDto } from 'src/app/studying/models/UserDto';

export class Notification {
  id: Guid;
  fromDate: Date;
  dueDate: Date;
  message: string;
  priority: NotificationPriority;
  type: number;
  users: UserDto[];
  color: string;

  constructor(model: Partial<Notification>) {
    this.id = model.id;
    this.fromDate = model.fromDate;
    this.dueDate = model.dueDate;
    this.message = model.message;
    this.priority = model.priority;
    this.type = model.type;
    this.users = model.users;
  }
}
