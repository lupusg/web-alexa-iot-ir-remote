import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagerComponent } from './manager.component';
import { SignalDetailsComponent } from './signal-details/signal-details.component';

const routes: Routes = [
  { path: '', component: ManagerComponent },
  { path: ':id', component: SignalDetailsComponent },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ManagerRoutingModule { }
