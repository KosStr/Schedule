import { Guid } from "guid-typescript/dist/guid";
import { Faculty } from "src/app/core/enums/faculty.enum";
import { AppointmentDto } from "./AppiontmentDto";
import { UserDto } from "./UserDto";

export class GroupDto {
    id: Guid;
    name: string;
    faculty: Faculty;
    members = new Array<UserDto>();
    appointments = new Array<AppointmentDto>();

    constructor(model: Partial<GroupDto>) {
        this.id = model.id;
        this.name = model.name;
        this.faculty = model.faculty;
        this.members = model.members;
        this.appointments = model.appointments;
    }
}