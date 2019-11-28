import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'battle' },
  { path: 'battle', loadChildren: './features/battle/battle.module#BattleModule'},
  { path: 'auth', loadChildren: './features/authentication/authentication.module#AuthenticationModule' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
