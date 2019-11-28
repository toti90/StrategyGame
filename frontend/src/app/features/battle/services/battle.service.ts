import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IInitialInfosDTO } from "../models/initialInfo.model";
import { ApiCallService } from "src/app/core/services/api-call.service";

@Injectable()
export class BattleService {
  constructor(private apiCallService: ApiCallService) {}

  getInitialInfos(): Observable<IInitialInfosDTO> {
    return this.apiCallService.getInitialInfos();
  }
}
