import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { getLocaleDateTimeFormat } from '@angular/common';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  msg: string;
  constructor(private userService: UserService,private router: Router) {}
  register(registerUser) {
    //registerUser.User_CreatedDateTime=new Date();
    console.log(registerUser);
    this.userService
      .submitRegister(registerUser)
      .subscribe(
        data => (this.msg = 'Registered Successfully'),
        error => (this.msg = 'Error Generated')
      );
  }
  ngOnInit() {}
  loginPage() {
    //this.router.navigate(['../main/login']);
    this.router.navigate(['../login']);
  }
}
