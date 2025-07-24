import { HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

export class HttpErrorHandler {
  static handleError(error: HttpErrorResponse | CdbError): Observable<never> {
    let errorMessage: string;

    if (error instanceof HttpErrorResponse) {
      // Você pode personalizar isso conforme os campos da API
      errorMessage = `Erro ${error.status}: ${error.message}`;
    } else {
      errorMessage = error?.message || 'Erro desconhecido';
    }

    console.error('Erro capturado:', errorMessage);
    return throwError(() => new Error(errorMessage));
  }
}

export interface CdbError {
  message: string;
}