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
  protocolIdSelected = 0;
  sortSelected = 'dateDesc';
  sortOptions = [
    { name: 'Alphabetical', value: 'nameAsc' },
    { name: 'Alphabetical descendent', value: 'nameDesc' },
    { name: 'Protocol', value: 'protocolAsc' },
    { name: 'Protocol descendent', value: 'protocolDesc' },
    { name: 'New', value: 'dateDesc' },
    { name: 'Old', value: 'dateAsc' },
  ];

  constructor(private managerService: ManagerService) {}

  ngOnInit(): void {
    this.getSignals();
    this.getProtocols();
  }

  getSignals() {
    this.managerService.getSignals(this.protocolIdSelected, this.sortSelected).subscribe({
      next: (response) => (this.signals = response.data),
      error: (error) => console.log(error),
    });
  }

  getProtocols() {
    this.managerService.getProtocols().subscribe({
      next: (response) =>
        (this.protocols = [{ id: 0, name: 'All' }, ...response]),
      error: (error) => console.log(error),
    });
  }

  onProtocolSelected(protocolId: number) {
    this.protocolIdSelected = protocolId;
    this.getSignals();
  }

  onSortSelected($event: any) {
    this.sortSelected = $event.target.value;
    console.log($event.target.value);
    this.getSignals();
  }
}
