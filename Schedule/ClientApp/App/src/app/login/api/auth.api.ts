import {environment} from "../../../environments/environment";
import {Injectable} from "@angular/core";

const URL = environment.apiUrl;

@Injectable()
export class TokenApi {
  LOGIN_URL = `${URL}account/login`;
  REGISTER_URL = `${URL}account/register`;
  REFRESH_URL = `${URL}account/refresh`;
}
