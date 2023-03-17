import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ManagerParams } from '../shared/models/managerParams';
import { Pagination } from '../shared/models/pagination';
import { Protocol } from '../shared/models/protocol';
import { Signal } from '../shared/models/signal';

@Injectable({
  providedIn: 'root',
})
export class ManagerService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getSignals(managerParams: ManagerParams) {
    let params = new HttpParams();

    if (managerParams.protocolId > 0) params = params.append('protocolId', managerParams.protocolId);
    params = params.append('sort', managerParams.sort);
    params = params.append('pageIndex', managerParams.pageIndex);
    params = params.append('pageSize', managerParams.pageSize);
    if (managerParams.search) params = params.append('search', managerParams.search);

    return this.http.get<Pagination<Signal[]>>(
      this.baseUrl + 'signals', {params} 
    );
  }

  getSignal(id: number) {
    return this.http.get<Signal>(this.baseUrl + 'signals/' + id);
  }

  getProtocols() {
    return this.http.get<Protocol[]>(this.baseUrl + 'signals/protocols');
  }

  editSignal(id: any, values: any) {
    return this.http.put(this.baseUrl + 'signals/' + id, values);
  }

  deleteSignal(id?: number) {
    return this.http.delete(this.baseUrl + 'signals/' + id);
  }
}
