import { Component, OnInit, Input } from "@angular/core";
import { IBuildingDTO } from "../../models/Buildings.model";

@Component({
  selector: "app-building-card",
  templateUrl: "./building-card.component.html",
  styleUrls: ["./building-card.component.scss"]
})
export class BuildingCardComponent implements OnInit {
  @Input() building: IBuildingDTO;

  constructor() {}

  ngOnInit() {
    console.log(this.building);
  }
}
