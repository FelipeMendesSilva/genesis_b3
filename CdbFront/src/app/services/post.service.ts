import { Injectable } from '@angular/core';
import { CDB_API } from '../app.api';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError, catchError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PostService {
  private readonly cdbUrl = `${CDB_API}/api/cdb/yield`;

  constructor(private readonly http: HttpClient) { }

  cdbPost(cdbInitialAmount: number, cdbMonths: number): Observable<CdbResponse<CdbData>> {
    const payload = {
      initialAmount: cdbInitialAmount,
      months: cdbMonths
    };

    return this.http.post<CdbResponse<CdbData>>(this.cdbUrl, payload).pipe(
      catchError(HttpErrorHandler.handleError));
  }
}
export interface CdbResponse<T> {
  statusCode: number;
  data: T | null;
  errorMessage: string | null;
}

export interface CdbData {
  grossAmount: number;
  netAmount: number;
}

class HttpErrorHandler {
  static handleError(error: HttpErrorResponse | CdbError): Observable<never> {
    let errorMessage: string;

    if (error instanceof HttpErrorResponse) {
      errorMessage = `Erro ${error.status}: ${error.message}`;
    } else {
      errorMessage = error?.message || 'Erro desconhecido';
    }

    console.error('Erro capturado:', errorMessage);
    return throwError(() => new Error(errorMessage));
  }
}

interface CdbError {
  message: string;
}
