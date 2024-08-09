import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AnnualReportService } from '../services/annual-report.service';

@Component({
  selector: 'app-annual-report-details',
  templateUrl: './annual-report-details.component.html',
  styleUrls: ['./annual-report-details.component.scss']
})
export class AnnualReportDetailsComponent implements OnInit {
  year!: number;
  reports: any = {}; 
  reportDetails: any[] = []; 
  errorMessage: string = '';

  constructor(
    private route: ActivatedRoute, 
    private annualReportService: AnnualReportService,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.year = +params.get('year')!;
      this.loadReportDetails(this.year);
    });
  }

  // loadReportDetails(year: number): void {
  //   this.reports = {
  //     year: year,
  //     totalTerms: 12,
  //     totalExpense: 150000,
  //     createdDate: new Date('2023-12-20'),
  //     totalDepartments: 5
  //   };
  
  //   this.reportDetails = [
  //     { department: 'HR', totalExpense: 30000, biggestExpenditure: 15000, costType: 'Salaries' },
  //     { department: 'IT', totalExpense: 50000, biggestExpenditure: 20000, costType: 'Hardware' },
  //     { department: 'Marketing', totalExpense: 20000, biggestExpenditure: 10000, costType: 'Campaigns' }
  //   ];
  
  //   console.log('Reports:', this.reports); 
  // }

  loadReportDetails(year: number): void {
    this.annualReportService.getAnnualReportsByYear(year).subscribe(
      (data) => {
        console.log('API Data:', data); // Kiểm tra dữ liệu từ API
        this.reports = data;
        this.reportDetails = data.details;
      },
      (error) => {
        console.error('Error:', error);
      }
    );
  }
  
}
