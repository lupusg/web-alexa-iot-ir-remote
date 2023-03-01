import { Component, OnInit } from '@angular/core';
import { ManagerParams } from '../shared/models/managerParams';
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
  managerParams = new ManagerParams();
  sortOptions = [
    { name: 'Alphabetical', value: 'nameAsc' },
    { name: 'Alphabetical descendent', value: 'nameDesc' },
    { name: 'Protocol', value: 'protocolAsc' },
    { name: 'Protocol descendent', value: 'protocolDesc' },
    { name: 'New', value: 'dateDesc' },
    { name: 'Old', value: 'dateAsc' },
  ];
  totalCount = 0;

  constructor(private managerService: ManagerService) {}

  ngOnInit(): void {
    this.getSignals();
    this.getProtocols();
  }

  getSignals() {
    this.managerService.getSignals(this.managerParams).subscribe({
      next: (response) => {
        this.signals = response.data
        this.managerParams.pageIndex = response.pageIndex;
        this.managerParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
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
    this.managerParams.protocolId = protocolId;
    this.getSignals();
  }

  onSortSelected($event: any) {
    this.managerParams.sort = $event.target.value;
    console.log($event.target.value);
    this.getSignals();
  }

  onPageChanged($event: any) {
    if (this.managerParams.pageIndex !== $event) {
      this.managerParams.pageIndex = $event.page;
      this.getSignals();
    }
  }
}
