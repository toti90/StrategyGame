import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IInitialInfosDTO } from "../models/initialInfo.model";
import { ApiCallService } from "src/app/core/services/api-call.service";
import { IBuildingDTO } from "../models/Buildings.model";
import { IDevelopmentDTO } from "../models/Developments.model";

@Injectable()
export class BattleService {
  constructor(private apiCallService: ApiCallService) {}

  getInitialInfos(): Observable<IInitialInfosDTO> {
    return this.apiCallService.getInitialInfos();
  }

  getBuildings(): Observable<IBuildingDTO[]> {
    return this.apiCallService.getBuildings();
  }

  getDevelopments(): Observable<IDevelopmentDTO[]> {
    return this.apiCallService.getDevelopments();
  }
}
