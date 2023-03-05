import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ManagerComponent } from './manager/manager.component';
import { SignalDetailsComponent } from './manager/signal-details/signal-details.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'manager', component: ManagerComponent },
  { path: 'signal/:id', component: SignalDetailsComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
