import { Guid } from "guid-typescript/dist/guid";
import { UserDto } from "./UserDto";

export class AppointmentDto {
    id : Guid;
    fromDate: Date;
    dueDate: Date;
    isCancelled: boolean;
    isOnline: boolean;
    link: string;
    subject: Object;
    teacher: UserDto;
    task: Object;

    constructor(model: Partial<AppointmentDto>) {
        this.id = model.id;
        this.fromDate = model.fromDate;
        this.dueDate = model.dueDate;
        this.isCancelled = model.isCancelled;
        this.isOnline = model.isOnline;
        this.link = model.link;
        this.subject = model.subject;
        this.teacher = model.teacher;
        this.task = model.task;
    }
}