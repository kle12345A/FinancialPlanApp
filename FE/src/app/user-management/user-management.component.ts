import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ConfirmDeleteTermComponent } from '../message/confirm-delete-term/confirm-delete-term.component';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrl: './user-management.component.scss'
})
export class UserManagementComponent {
  constructor(private router: Router, public dialog: MatDialog) {}

  openConfirmationDialog(): void {
    const dialogRef = this.dialog.open(ConfirmDeleteTermComponent);

  }
}
