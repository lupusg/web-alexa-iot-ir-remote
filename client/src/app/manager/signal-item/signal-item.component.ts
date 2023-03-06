import { Component, Input } from '@angular/core';
import { Signal } from 'src/app/shared/models/signal';

@Component({
  selector: 'tr[app-signal-item]',
  templateUrl: './signal-item.component.html',
  styleUrls: ['./signal-item.component.scss'],
})
export class SignalItemComponent {
  @Input() signal?: Signal;
}
