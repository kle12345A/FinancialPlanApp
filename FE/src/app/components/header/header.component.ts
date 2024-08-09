import { Component } from '@angular/core';
import {NavigationEnd, Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { UserService } from '../../services/user.service';



@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  showNav = true;
  showLogin = true;

  constructor(private router: Router, public userService: UserService, private authService: AuthService) { }

  ngOnInit(): void {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        const isResetPasswordPage = this.router.url.includes('reset-password');
        this.showNav = !isResetPasswordPage;
        this.showLogin = !isResetPasswordPage;
      }
    });

    this.userService.user$.subscribe(user => {
      // Update the component based on the user state if needed
    });
  }

  confirmLogout() {
    if (confirm("Are you sure you want to logout?")) {
      this.logout();
    }
  }

  logout() {
    this.authService.logout().subscribe({
      next: () => {
        this.userService.logout(); // Clear the user state
        this.router.navigate(['/login']); // Redirect to login page
      },
      error: (error) => {
        console.error('Logout failed', error);
      }
    });
  }
}
