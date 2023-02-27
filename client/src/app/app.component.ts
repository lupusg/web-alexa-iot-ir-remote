import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Pagination } from './shared/models/pagination';
import { Signal } from './shared/models/signal';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  // styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  signals: Signal[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<Pagination<Signal[]>>('https://localhost:5001/api/signals?pageSize=30')
      .subscribe({
        next: (response: any) => { this.signals = response.data},
        error: (err) => { console.log(err) },
        complete: () => { console.log('Completed') }
      });
  }
}
