import { Component, OnInit, Input } from "@angular/core";
import { IDevelopmentDTO } from "../../models/Developments.model";

@Component({
  selector: "app-development-card",
  templateUrl: "./development-card.component.html",
  styleUrls: ["./development-card.component.scss"]
})
export class DevelopmentCardComponent implements OnInit {
  @Input() development: IDevelopmentDTO;

  constructor() {}

  ngOnInit() {
    console.log(this.development);
  }
}
