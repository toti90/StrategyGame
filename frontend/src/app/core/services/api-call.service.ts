import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import {
  IUserRequest,
  IUserResponseDTO
} from "src/app/features/authentication/models/user";
import { Observable } from "rxjs";
import { IInitialInfosDTO } from "src/app/features/battle/models/initialInfo.model";

@Injectable({
  providedIn: "root"
})
export class ApiCallService {
  constructor(private http: HttpClient) {}

  loginUser(userRequest: IUserRequest): Observable<IUserResponseDTO> {
    return this.http.post<IUserResponseDTO>(
      `${environment.serverURL}/user/login`,
      userRequest,
      {
        headers: { "content-type": "application/json" }
      }
    );
  }

  registerUser(userRequest: IUserRequest): Observable<IUserResponseDTO> {
    return this.http.post<IUserResponseDTO>(
      `${environment.serverURL}/user/register`,
      userRequest,
      {
        headers: { "content-type": "application/json" }
      }
    );
  }

  getInitialInfos(): Observable<IInitialInfosDTO> {
    return this.http.get<IInitialInfosDTO>(`${environment.serverURL}/game`, {
      headers: { "content-type": "application/json" }
    });
  }
}
