import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import {
  UserRequest,
  UserResponseDTO
} from "src/app/features/authentication/models/user";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class ApiCallService {
  constructor(private http: HttpClient) {}

  loginUser(userRequest: UserRequest): Observable<UserResponseDTO> {
    return this.http.post<UserResponseDTO>(
      `${environment.serverURL}/user/login`,
      userRequest,
      {
        headers: { "content-type": "application/json" }
      }
    );
  }
}
