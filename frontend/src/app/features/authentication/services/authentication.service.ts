import { Injectable } from "@angular/core";
import { UserRequest, UserResponseDTO } from "../models/user";
import { ApiCallService } from "src/app/core/services/api-call.service";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class AuthenticationService {
  constructor(private apiCallService: ApiCallService) {}

  loginUser(userRequest: UserRequest): Observable<UserResponseDTO> {
    return this.apiCallService.loginUser(userRequest);
  }

  registerUser(userRequest: UserRequest): Observable<UserResponseDTO> {
    return this.apiCallService.registerUser(userRequest);
  }
}
