import { Component, OnInit, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from "@angular/material";

@Component({
  selector: "app-popup",
  templateUrl: "./popup.component.html",
  styleUrls: ["./popup.component.scss"]
})
export class PopupComponent implements OnInit {
  private buttonDisabled = true;

  constructor(
    public dialogRef: MatDialogRef<PopupComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: any
  ) {}

  ngOnInit() {}

  selectTile(tile: object) {
    this.buttonDisabled = false;
    this.data.data.forEach(building => (building.selected = false));
    tile["selected"] = !tile["selected"];
  }

  buy(tile: object) {
    let selectedObject = {
      object: this.data.data.filter(d => d.selected === true)[0],
      category: this.data.category
    };
    this.dialogRef.close(selectedObject);
  }
}
