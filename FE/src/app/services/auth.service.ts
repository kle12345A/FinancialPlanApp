import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'https://localhost:7273/api/Auth'; // URL của API
  private tokenKey = 'jwtToken';

  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    const loginRequest = { email, password };
    return this.http.post<any>(`${this.baseUrl}/login`, loginRequest)
      .pipe(
        map(response => {
          if (response && response.token) {
            this.setToken(response.token);
          }
          return response;
        })
      );
  }

  setToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  logout(): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/logout`, {})
      .pipe(
        map(() => {
          this.removeToken();
        })
      );
  }

  private removeToken(): void {
    localStorage.removeItem(this.tokenKey);
  }
}
