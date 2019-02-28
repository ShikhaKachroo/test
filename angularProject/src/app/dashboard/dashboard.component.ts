import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  username = '';
  userClaims: any;
  constructor(private userService: UserService, private router: Router) {
    this.userService.getUserClaims().subscribe((data: any) => {
      console.log(data);
      this.userClaims = data;
 
    });
    // this.userService
    //   .getUserName()
    //   .subscribe(
    //     data => (this.username = data.toString()),
    //     error => this.router.navigate(['/main/login'])
    //   );
  }

  ngOnInit() {}
  logout() {
    localStorage.removeItem('userToken');
    //this.router.navigate(['/main/login']);
    this.router.navigate(['/login']);
  }
}



