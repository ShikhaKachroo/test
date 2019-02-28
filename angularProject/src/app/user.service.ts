import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams , HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class UserService {
  constructor(private httpClient: HttpClient,private router: Router) {}

  // submitRegister(registerUser: any): Observable<string> {
  //   return this.httpClient.post(
  //     'http://localhost:9999/users/register',
  //     registerUser,
  //     {
  //       responseType: 'text'
  //     }
  //   );
  // }
submitRegister(registerUser: any): Observable<any> {
    return this.httpClient.post(
      'http://localhost:50393/api/user',registerUser
     );
  }
  login(loginInfo: any) {

    this.httpClient
      .post('http://localhost:9999/users/login', loginInfo)
      .subscribe(
        data => {
          console.log(data);
          localStorage.setItem('token', data.toString());
          this.router.navigate(['/dash']);
        },
        error => {console.log(error)}
      );
  }
  userAuthentication(userName, password) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
    return this.httpClient.post('http://localhost:50393' + '/token', data, { headers: reqHeader });
  }
  getUserClaims(){
    return  this.httpClient.get('http://localhost:50393'+'/api/GetUserClaims');
   }
  getUserName(): Observable<string>{
    return this.httpClient.get(
      'http://localhost:9999/users/username',
      {
        responseType: 'text',
        params: new HttpParams().append('token',localStorage.getItem('token'))
      }
    );
  }
}
