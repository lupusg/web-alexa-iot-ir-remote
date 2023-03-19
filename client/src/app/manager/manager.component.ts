import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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
  @ViewChild('search') searchTerm?: ElementRef;
  signals: Signal[] = [];
  protocols: Protocol[] = [];
  managerParams = new ManagerParams();
  sortOptions = [
    { name: 'Id', value: 'idAsc' },
    { name: 'Id descendent', value: 'idDesc' },
    { name: 'Alphabetical', value: 'nameAsc' },
    { name: 'Alphabetical descendent', value: 'nameDesc' },
    { name: 'New', value: 'dateDesc' },
    { name: 'Old', value: 'dateAsc' },
    { name: 'Protocol', value: 'protocolAsc' },
    { name: 'Protocol descendent', value: 'protocolDesc' },
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
    this.managerParams.pageIndex = 1;
    this.getSignals();
  }

  onSortSelected(event: any) {
    this.managerParams.sort = event.target.value;
    console.log(event.target.value);
    this.getSignals();
  }

  onPageChanged(event: any) {
    if (this.managerParams.pageIndex !== event) {
      this.managerParams.pageIndex = event;
      this.getSignals();
    }
  }

  onSearch() {
    this.managerParams.search = this.searchTerm?.nativeElement.value;
    this.managerParams.pageIndex = 1;
    this.getSignals();
  }

  onReset() {
    if(this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.managerParams = new ManagerParams();
    this.getSignals();
  }
}
