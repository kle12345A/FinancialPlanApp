import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  loginError: string | null = null; 

  constructor(private router: Router, private authService: AuthService, private userService: UserService) { }

  onBack() {
    this.router.navigate(['/home']); 
  }

  onLogin() {
    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        console.log('Login successful', response);
        this.userService.setUser(response.user);  
        this.router.navigate(['/home']); 
      },
      error: (error) => {
        console.error('Login failed', error);
        this.loginError = 'Login failed. Please check your email and password.';
      }
    });
  }
}
