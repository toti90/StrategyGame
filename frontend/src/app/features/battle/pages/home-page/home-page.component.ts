import { Component, OnInit } from "@angular/core";
import { BattleService } from "../../services/battle.service";
import { IInitialInfosDTO } from "../../models/initialInfo.model";

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
    "Harck",
    "Ranglista",
    "Sereg"
  ];
  constructor(private battleService: BattleService) {}

  ngOnInit() {
    this.battleService
      .getInitialInfos()
      .subscribe((initialInfos: IInitialInfosDTO) => {
        console.log(initialInfos);
        this.initialInfos = initialInfos;
      });
  }
}
