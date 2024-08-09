import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-home', // or the appropriate selector
  templateUrl: './home.component.html', // or the appropriate template URL
  styleUrls: ['./home.component.scss'] // or the appropriate style URL
})
export class HomeComponent implements OnInit {
  isLoggedIn: boolean = false;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {

  }
}
