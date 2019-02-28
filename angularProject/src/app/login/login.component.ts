import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private userService: UserService, private router: Router,
              private activatedRoute: ActivatedRoute) {}

  ngOnInit() {}

  registerUser() {
    //this.router.navigate(['../main/register']);//, { relativeTo: this.activatedRoute }]);
    this.router.navigate(['../register']);
  }
 
  // login(userInfo) {
  //  console.log(userInfo);
  //  this.userService.login(userInfo);
  // }

  
  login(u,p) {
    //console.log(userInfo);
    this.userService.userAuthentication(u,p)
    .subscribe((data : any)=>{
      localStorage.setItem('userToken',data.access_token);
      this.router.navigate(['/dash']);
      console.log(data.access_token);
    },
    (err : HttpErrorResponse)=>{
      console.log(err);
     // this.isLoginError = true;
    });;
   }
}
