import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDeleteTermComponent } from '../message/confirm-delete-term/confirm-delete-term.component';

interface Term {
  name: string;
  startDate: string;
  endDate: string;
  status: string;
}
@Component({
  selector: 'app-term-management',
  templateUrl: './term-management.component.html',
  styleUrl: './term-management.component.scss'
})
export class TermManagementComponent {
  terms: Term[] = [
    {
      name: 'Financial plan December Q3 2021',
      startDate: '25 December 2021',
      endDate: '30 December 2021',
      status: 'In-progress'
    },
    {
      name: 'Financial plan December Q3 2021',
      startDate: '25 November 2021',
      endDate: '30 November 2021',
      status: 'Closed'
    },
    {
      name: 'Financial plan November Q3 2021',
      startDate: '25 October 2021',
      endDate: '30 October 2021',
      status: 'Closed'
    },
    {
      name: 'Financial plan October Q3 2021',
      startDate: '25 September 2021',
      endDate: '30 September 2021',
      status: 'Closed'
    }
  ];

  constructor(private router: Router, public dialog: MatDialog) {}

  termDetails(term: Term): void {

    this.router.navigate(['/term-details']);
  }

  editTerm(term: Term): void {
    this.router.navigate(['/edit-term']);
  }

  deleteTerm(term: Term): void {
    const dialogRef = this.dialog.open(ConfirmDeleteTermComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.terms = this.terms.filter(t => t !== term);
        console.log('Delete:', term);
      }
    });
  }
}
