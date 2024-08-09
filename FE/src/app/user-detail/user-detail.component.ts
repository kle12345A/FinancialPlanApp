import { Component } from '@angular/core';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent {
  buttonText: string = 'Activate user';
  userStatus: string = 'Inactive';

  toggleButtonText() {
    if (this.buttonText === 'Activate user') {
      this.buttonText = 'De-Activate user';
      this.userStatus = 'Active';
    } else {
      this.buttonText = 'Activate user';
      this.userStatus = 'Inactive';
    }
  }
}
