import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-serve-error',
  templateUrl: './serve-error.component.html',
  styleUrls: ['./serve-error.component.scss'],
})
export class ServeErrorComponent {
  error: any;

  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    this.error = navigation?.extras?.state?.['error'];
  }
}
