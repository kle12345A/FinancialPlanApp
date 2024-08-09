import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ConfirmDeleteTermComponent } from '../../message/confirm-delete-term/confirm-delete-term.component';

@Component({
  selector: 'app-financial-staff-financial-plan-list',
  templateUrl: './financial-staff-financial-plan-list.component.html',
  styleUrl: './financial-staff-financial-plan-list.component.scss'
})
export class FinancialStaffFinancialPlanListComponent {
  constructor(private router: Router, public dialog: MatDialog) {}

  openConfirmationDialog(): void {
    const dialogRef = this.dialog.open(ConfirmDeleteTermComponent);

  }
}
