import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ConfirmDeleteTermComponent } from '../message/confirm-delete-term/confirm-delete-term.component';
@Component({
  selector: 'app-monthly-report-list',
  templateUrl: './monthly-report-list.component.html',
  styleUrl: './monthly-report-list.component.scss'
})
export class MonthlyReportListComponent {
  constructor(private router: Router, public dialog: MatDialog) {}

  openConfirmationDialog(): void {
    const dialogRef = this.dialog.open(ConfirmDeleteTermComponent);

  }
}
