import { NgModule } from "@angular/core";
import { SharedModule } from "src/app/shared/shared.module";
import { BattleRoutingModule } from "./battle-routing.module";
import { BattleService } from "./services/battle.service";
import { CompComponent } from "./components/comp/comp.component";
import { AuthGuard } from "src/app/core/guards/auth.guard";
import { HomePageComponent } from "./pages/home-page/home-page.component";

@NgModule({
  imports: [SharedModule, BattleRoutingModule],
  providers: [BattleService, AuthGuard],
  declarations: [CompComponent, HomePageComponent]
})
export class BattleModule {}
