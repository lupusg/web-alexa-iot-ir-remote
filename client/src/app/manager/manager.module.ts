import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerComponent } from './manager.component';
import { SignalItemComponent } from './signal-item/signal-item.component';

@NgModule({
  declarations: [
    ManagerComponent,
    SignalItemComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ManagerComponent
  ]
})
export class ManagerModule { }
