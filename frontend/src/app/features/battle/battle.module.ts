import { NgModule } from "@angular/core";
import { SharedModule } from "src/app/shared/shared.module";
import { BattleRoutingModule } from "./battle-routing.module";
import { BattleService } from "./services/battle.service";
import { AuthGuard } from "src/app/core/guards/auth.guard";
import { HomePageComponent } from "./pages/home-page/home-page.component";
import { PopupComponent } from "./components/popup/popup.component";
import { MatDialogModule } from "@angular/material";
import { BuildingCardComponent } from './components/building-card/building-card.component';
import { DevelopmentCardComponent } from './components/development-card/development-card.component';

@NgModule({
  imports: [SharedModule, BattleRoutingModule, MatDialogModule],
  providers: [BattleService, AuthGuard, MatDialogModule],
  declarations: [HomePageComponent, PopupComponent, BuildingCardComponent, DevelopmentCardComponent],
  entryComponents: [PopupComponent]
})
export class BattleModule {}
