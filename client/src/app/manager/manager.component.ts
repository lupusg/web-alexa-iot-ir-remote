import { Component, OnInit } from '@angular/core';
import { Signal } from '../models/signal';
import { ManagerService } from './manager.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.scss'],
})
export class ManagerComponent implements OnInit {
  signals: Signal[] = [];

  constructor (private managerService: ManagerService) {}

  ngOnInit(): void {
    this.managerService.getSignals().subscribe({
      next: (response: any) => {
        this.signals = response.data;
      }
    });
  }
}
