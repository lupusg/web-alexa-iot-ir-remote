import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Signal } from 'src/app/shared/models/signal';
import { ManagerService } from '../manager.service';

@Component({
  selector: 'app-signal-details',
  templateUrl: './signal-details.component.html',
  styleUrls: ['./signal-details.component.scss']
})
export class SignalDetailsComponent implements OnInit {
  signal?: Signal;

  constructor(private managerService: ManagerService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadSignal();
  }

  loadSignal() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) this.managerService.getSignal(+id).subscribe({
      next: signal => this.signal = signal,
      error: error => console.log(error)
    })
  }
}