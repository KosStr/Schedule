
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { tap, takeUntil, mergeMap } from 'rxjs/operators';
import { Guid } from 'guid-typescript/dist/guid';
import { Role } from 'src/app/core/enums/role.enum';
import { UserDto } from '../../models/UserDto';
import { UserService } from '../../services/user-service';
import { GroupService } from '../../services/group-service';
import { GroupDto } from '../../models/GroupDto';
import { CurrentUserService } from 'src/app/core/services/current-user.service';

@Component({
  selector: 'app-group-info',
  templateUrl: './group-info.component.html',
  styleUrls: ['./group-info.component.css'],
})
export class GroupInfoComponent implements OnInit, OnDestroy {
  students: UserDto[];
  teacher: UserDto;
  faculty = '';
  destroy$ = new Subject<boolean>();

  constructor(
    private userService: UserService,
    private groupService: GroupService,
    private currentUserService: CurrentUserService
  ) {}

  ngOnInit() {
    this.getGroupMembers();
  }

  ngOnDestroy(): void {
    this.destroy$.next(false);
    this.destroy$.unsubscribe();
  }

  private getGroupMembers(): void {
    this.userService
      .getMembers()
      .pipe(
        tap((members: UserDto[]) => {
          if (members?.length) {
            this.students = members.filter(
              (m: UserDto) => m.role === Role.Student
            );
            this.teacher = members.find(
              (m: UserDto) => m.role === Role.Teacher
            );
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }
}
