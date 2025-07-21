import { Injectable } from '@angular/core';
import { CDB_API } from '../app.api';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PostService {
  private cdbUrl = `${CDB_API}/api/cdb`;

  constructor(private http: HttpClient) {}

  cdbPost(cdbValue:number, cdbMonths:number): Observable<CdbResponse> {
    const payload = {
      value: cdbValue,
      months: cdbMonths
    };

    return this.http.post<CdbResponse>(this.cdbUrl, payload);
  }
}
export interface CdbResponse {
  GrossAmount: number;
  NetAmount: number;
}

