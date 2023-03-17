import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { Signal } from 'src/app/shared/models/signal';
import { ManagerService } from '../manager.service';

@Component({
  selector: 'app-signal-details',
  templateUrl: './signal-details.component.html',
  styleUrls: ['./signal-details.component.scss'],
})
export class SignalDetailsComponent implements OnInit {
  signal?: Signal;
  signalForm = new FormGroup({
    name: new FormControl(''),
    irData: new FormControl(''),
    assignedButton: new FormControl(''),
    createdAt: new FormControl(''),
  });

  constructor(
    private managerService: ManagerService,
    public accountService: AccountService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (!this.accountService.isLoggedIn())
      this.signalForm.disable();
    
    this.loadSignal();
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
