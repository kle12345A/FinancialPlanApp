import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AnnualReportService } from '../services/annual-report.service';

@Component({
  selector: 'app-annual-report',
  templateUrl: './annual-report.component.html',
  styleUrls: ['./annual-report.component.scss']
})
export class AnnualReportComponent implements OnInit {
  reports: any[] = [];
  filteredReports: any[] = [];
  errorMessage: string = '';
  searchQuery: string = '';
  totalResults: number = 0; // Thêm thuộc tính này

  constructor(private annualReportService: AnnualReportService, private router: Router) { }

  ngOnInit(): void {
    this.getAnnualReports();
  }

  getAnnualReports(): void {
    this.annualReportService.getAnnualReports().subscribe(
      (data) => {
        this.reports = data;
        this.filteredReports = data;
        this.totalResults = data.length; // Khởi tạo với tổng số báo cáo
      },
      (error) => this.errorMessage = error
    );
  }

  search(): void {
    this.filterReports();
  }

  filterReports(): void {
    if (!this.searchQuery) {
      this.filteredReports = this.reports;
    } else {
      const yearQuery = parseInt(this.searchQuery, 10);
      this.filteredReports = this.reports.filter(report =>
        report.year === yearQuery
      );
    }

    this.totalResults = this.filteredReports.length; // Cập nhật tổng số kết quả

    if (this.filteredReports.length === 0) {
      this.errorMessage = 'No items match your credentials, please try again.';
    } else {
      this.errorMessage = '';
    }
  }
}
