import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ManagerParams } from '../shared/models/managerParams';
import { Pagination } from '../shared/models/pagination';
import { Protocol } from '../shared/models/protocol';
import { Signal } from '../shared/models/signal';

@Injectable({
  providedIn: 'root',
})
export class ManagerService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getSignals(managerParams: ManagerParams) {
    let params = new HttpParams();

    if (managerParams.protocolId > 0) params = params.append('protocolId', managerParams.protocolId);
    params = params.append('sort', managerParams.sort);
    params = params.append('pageIndex', managerParams.pageIndex);
    params = params.append('pageSize', managerParams.pageSize);

    return this.http.get<Pagination<Signal[]>>(
      this.baseUrl + 'signals', { params }
    );
  }

  getProtocols() {
    return this.http.get<Protocol[]>(this.baseUrl + 'signals/protocols');
  }
}
