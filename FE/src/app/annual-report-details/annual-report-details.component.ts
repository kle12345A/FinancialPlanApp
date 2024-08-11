import { Component, OnInit } from '@angular/core';
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
  paginatedReportDetails: any[] = []; 
  originalReportDetails: any[] = []; 
  searchByDepartment: string = '';
  errorMessage: string = '';
  itemsPerPage: number = 10;
  currentPage: number = 1;
  Math = Math;

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

  loadReportDetails(year: number): void {
    this.annualReportService.getAnnualReportsByYear(year).subscribe(
      (data) => {
        console.log('Annual Report Data:', data);
        this.reports = data; 
        if (Array.isArray(this.reports) && this.reports.length > 0) {
          this.reportDetails = this.reports[0].reportDetails || []; 
          this.originalReportDetails = [...this.reportDetails];
          this.updatePaginatedReportDetails();
        }
      },
      (error) => {
        console.error('Error:', error);
        this.errorMessage = 'Failed to load report details.';
      }
    );
  }

  search(): void {
    if (this.searchByDepartment.trim()) {
      this.annualReportService.searchReportByDepartment(this.year, this.searchByDepartment).subscribe(
        (data) => {
          console.log('Search Results:', data);
          this.reportDetails = data || [];
          this.updatePaginatedReportDetails();
        },
        (error) => {
          console.error('Search Error:', error);
          this.errorMessage = 'Failed to search by department.';
        }
      );
    } else {
      this.reportDetails = [...this.originalReportDetails];
      this.updatePaginatedReportDetails();
    }
  }

  updatePaginatedReportDetails(): void {
    const start = (this.currentPage - 1) * this.itemsPerPage;
    const end = start + this.itemsPerPage;
    this.paginatedReportDetails = this.reportDetails.slice(start, end);
  }

  changePage(increment: number): void {
    const newPage = this.currentPage + increment;
    const maxPage = Math.ceil(this.reportDetails.length / this.itemsPerPage);
    if (newPage > 0 && newPage <= maxPage) {
      this.currentPage = newPage;
      this.updatePaginatedReportDetails();
    }
  }
}
