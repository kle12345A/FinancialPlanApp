import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-term-details',
  templateUrl: './term-details.component.html',
  styleUrl: './term-details.component.scss'
})
export class TermDetailsComponent {
  constructor(private router: Router) {}

  onCancel() {
    
    this.router.navigate(['/term-management']);
  }

  onEdit() {
  
    this.router.navigate(['/edit-term']);
  }
}
