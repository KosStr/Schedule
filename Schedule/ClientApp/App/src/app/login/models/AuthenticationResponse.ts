import {User} from "../../core/models/User";
import {ActionStatus} from "../../core/enums/action-status.enum";

export class AuthenticationResponse {
  accessToken: string;
  user: User;
  status: ActionStatus;
}
