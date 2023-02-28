import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Protocol } from '../shared/models/protocol';
import { Signal } from '../shared/models/signal';

@Injectable({
  providedIn: 'root',
})
export class ManagerService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getSignals() {
    return this.http.get<Pagination<Signal[]>>(
      this.baseUrl + 'signals?pageSize=30'
    );
  }

  getProtocols() {
    return this.http.get<Protocol[]>(this.baseUrl + 'signals/protocols');
  }
}
