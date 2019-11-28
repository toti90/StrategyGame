import { Injectable } from "@angular/core";
import { IUserRequest, IUserResponseDTO } from "../models/user";
import { ApiCallService } from "src/app/core/services/api-call.service";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class AuthenticationService {
  constructor(private apiCallService: ApiCallService) {}

  loginUser(userRequest: IUserRequest): Observable<IUserResponseDTO> {
    return this.apiCallService.loginUser(userRequest);
  }

  registerUser(userRequest: IUserRequest): Observable<IUserResponseDTO> {
    return this.apiCallService.registerUser(userRequest);
  }
}
