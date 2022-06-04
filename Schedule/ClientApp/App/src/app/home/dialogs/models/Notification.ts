import { NotificationPriority } from 'src/app/core/enums/notification-priority';

export class Notification {
    fromDate: Date;
    dueDate: Date;
    message: string;
    priority: NotificationPriority;
    type: number;
    color: string;
}
