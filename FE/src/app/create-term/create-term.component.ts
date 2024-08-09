import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-term',
  templateUrl: './create-term.component.html',
  styleUrl: './create-term.component.scss'
})
export class CreateTermComponent {
  constructor(private router: Router) {}

  onCancel() {
    
    this.router.navigate(['/term-management']);
  }

  onSubmit() {
  
    this.router.navigate(['/term-management']);
  }
}
