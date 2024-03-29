import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/app/account/account.service';
import { Signal } from 'src/app/shared/models/signal';
import { ManagerService } from '../manager.service';
import { Protocol } from 'src/app/shared/models/protocol';

@Component({
  selector: 'app-signal-details',
  templateUrl: './signal-details.component.html',
  styleUrls: ['./signal-details.component.scss'],
})
export class SignalDetailsComponent implements OnInit {
  signal?: Signal;
  protocols: Protocol[] = [];
  signalForm = new FormGroup({
    name: new FormControl(''),
    irData: new FormControl(''),
    assignedButton: new FormControl(''),
    createdAt: new FormControl(''),
    signalProtocolId: new FormControl(''),
  });
  customSwitches = Array(10)
    .fill(0)
    .map((x, i) => i + 1);

  constructor(
    private managerService: ManagerService,
    public accountService: AccountService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (!this.accountService.isLoggedIn()) this.signalForm.disable();

    this.loadSignal();
    this.loadProtocols();
  }

  loadSignal() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id)
      this.managerService.getSignal(+id).subscribe({
        next: (signal) => {
          this.signalForm.patchValue(signal);
          this.signal = signal;
        },
        error: (error) => console.log(error),
      });
  }

  loadProtocols() {
    this.managerService.getProtocols().subscribe({
      next: (protocols) => {
        this.protocols = protocols;
      },
      error: (error) => console.log(error),
    })
  }

  updateSignal() {
    this.managerService
      .editSignal(this.signal?.id, this.signalForm.value)
      .subscribe({
        next: () => {
          this.router.navigateByUrl('/manager');
        },
        error: (error) => console.log(error),
      });
  }

  deleteSignal() {
    this.managerService.deleteSignal(this.signal?.id).subscribe({
      next: () => {
        this.router.navigateByUrl('/manager');
      },
      error: (error) => console.log(error),
    });
  }
}
