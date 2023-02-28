import { Component, OnInit } from '@angular/core';
import { Protocol } from '../shared/models/protocol';
import { Signal } from '../shared/models/signal';
import { ManagerService } from './manager.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.scss'],
})
export class ManagerComponent implements OnInit {
  signals: Signal[] = [];
  protocols: Protocol[] = [];

  constructor(private managerService: ManagerService) {}

  ngOnInit(): void {
    this.getSignals();
    this.getProtocols();
  }

  getSignals() {
    this.managerService.getSignals().subscribe({
      next: (response) => this.signals = response.data,
      error: (error) => console.log(error)
    });
  }

  getProtocols() {
    this.managerService.getProtocols().subscribe({
      next: (response) => this.protocols = response,
      error: (error) => console.log(error)
    });
  }
}
