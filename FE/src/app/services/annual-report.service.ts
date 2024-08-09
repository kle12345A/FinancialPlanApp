import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AnnualReportService {
  private baseUrl = 'https://localhost:7273/api/AnnualReport';
  constructor(private http: HttpClient) { }

  getAnnualReports(): Observable<any> {
    return this.http.get(`${this.baseUrl}/annual-reports`).pipe(
      catchError(this.handleError)
    );
  }

  getAnnualReportsByYear(year: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/annual-reports/${year}`).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Error: ${error.error.message}`;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
