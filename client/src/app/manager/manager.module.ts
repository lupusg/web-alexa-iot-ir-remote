import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerComponent } from './manager.component';
import { SignalItemComponent } from './signal-item/signal-item.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    ManagerComponent,
    SignalItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    ManagerComponent
  ]
})
export class ManagerModule { }
