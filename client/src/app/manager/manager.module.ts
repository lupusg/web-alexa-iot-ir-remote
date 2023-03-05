import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerComponent } from './manager.component';
import { SignalItemComponent } from './signal-item/signal-item.component';
import { SharedModule } from '../shared/shared.module';
import { SignalDetailsComponent } from './signal-details/signal-details.component';
import { RouterModule } from '@angular/router';
import { ManagerRoutingModule } from './manager-routing.module';

@NgModule({
  declarations: [
    ManagerComponent,
    SignalItemComponent,
    SignalDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ManagerRoutingModule
  ]
})
export class ManagerModule { }
