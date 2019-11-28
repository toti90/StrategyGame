import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { ExamplePageComponent } from "./pages/example/example.page.component";
import { AuthGuard } from "src/app/core/guards/auth.guard";

const routes: Routes = [
  { path: "", component: ExamplePageComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BattleRoutingModule {}
