import { Component, OnInit } from "@angular/core";
import { BattleService } from "../../services/battle.service";
import { IInitialInfosDTO } from "../../models/initialInfo.model";
import { LocalDbService } from "src/app/core/services/local-db.service";

@Component({
  selector: "app-home-page",
  templateUrl: "./home-page.component.html",
  styleUrls: ["./home-page.component.scss"]
})
export class HomePageComponent implements OnInit {
  private initialInfos: IInitialInfosDTO;
  private buttons = [
    "Épületek",
    "Támadás",
    "Fejlesztések",
    "Harc",
    "Ranglista",
    "Sereg"
  ];
  constructor(
    private battleService: BattleService,
    private localDbService: LocalDbService
  ) {}

  ngOnInit() {
    this.battleService
      .getInitialInfos()
      .subscribe((initialInfos: IInitialInfosDTO) => {
        console.log(initialInfos);
        this.initialInfos = initialInfos;
      });
  }

  logout(): void {
    this.localDbService.removeAccessToken();
  }
}
