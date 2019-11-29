import { Component, OnInit } from "@angular/core";
import { BattleService } from "../../services/battle.service";
import { IInitialInfosDTO } from "../../models/initialInfo.model";
import { LocalDbService } from "src/app/core/services/local-db.service";
import { MatDialog } from "@angular/material";
import { PopupComponent } from "../../components/popup/popup.component";
import { IBuilding } from "../../models/Buildings.model";

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
    private localDbService: LocalDbService,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.battleService
      .getInitialInfos()
      .subscribe((initialInfos: IInitialInfosDTO) => {
        this.initialInfos = initialInfos;
      });
  }

  logout(): void {
    this.localDbService.removeAccessToken();
  }

  getData(buttonName: string) {
    switch (buttonName) {
      case "Épületek":
        this.battleService
          .getBuildings()
          .subscribe((buildings: IBuilding[]) => {
            buildings.forEach(building => {
              building.selected = false;
              this.initialInfos.buildingGroups.forEach(bg =>
                bg.buildingId === building.buildingId
                  ? (building.own = bg.amount)
                  : (building.own = 0)
              );
            });
            this.openDialog(
              "Épületek",
              "buildings",
              buildings,
              "Megveszem",
              "Kattints rá, amelyiket szeretnéd megvenni",
              "Egyszerre csak egy épület épülhet"
            );
          });
    }
  }

  openDialog(
    title: string,
    category: string,
    data: any,
    buttonTitle: string,
    subTitle?: string,
    subSubTitle?: string
  ): void {
    const dialogRef = this.dialog.open(PopupComponent, {
      panelClass: "custom-dialog-container",
      data: { title, subTitle, subSubTitle, category, data, buttonTitle }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
    });
  }
}
