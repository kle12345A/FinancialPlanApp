import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmStartTermComponent } from '../message/confirm-start-term/confirm-start-term.component';
import { Router } from '@angular/router';
@Component({
  selector: 'app-edit-term',
  templateUrl: './edit-term.component.html',
  styleUrl: './edit-term.component.scss'
})
export class EditTermComponent {
  constructor(private router: Router, public dialog: MatDialog) {}

  openConfirmationDialog(): void {
    const dialogRef = this.dialog.open(ConfirmStartTermComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // User confirmed
        this.startTerm();
      } else {
        // User cancelled
      }
    });
  }

  startTerm(): void {
 
    console.log('Term started');
  }

  onCancel() {
    
    this.router.navigate(['/term-management']);
  }

  onSubmit() {
  
    this.router.navigate(['/term-management']);
  }
}
