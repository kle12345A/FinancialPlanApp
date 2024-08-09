import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private userSubject = new BehaviorSubject<any>(null); // Holds the current user state
  user$ = this.userSubject.asObservable(); // Observable to subscribe to user changes

  constructor() { }

  // Sets the current user and emits the new value
  setUser(user: any): void {
    this.userSubject.next(user);
  }

  // Gets the current user
  getUser(): any {
    return this.userSubject.value;
  }

  // Checks if the user is logged in
  isLoggedIn(): boolean {
    return this.userSubject.value !== null;
  }

  // Logs out the user by clearing the user state
  logout(): void {
    this.userSubject.next(null);
  }
}
