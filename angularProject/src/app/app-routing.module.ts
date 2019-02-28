import { DashboardComponent } from './dashboard/dashboard.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { UserComponent } from './user/user.component';
// const routes: Routes = [
//   { path: '', redirectTo: 'main', pathMatch: 'full' },
//   {
//     path: 'main',
//     component: MainComponent,
//     children: [
//       { path: '', redirectTo: 'login', pathMatch: 'full' },
//       { path: 'login', component: LoginComponent },
//       { path: 'register', component: RegisterComponent }
//     ]
//   },
//   { path: 'dash', component: DashboardComponent,canActivate:[AuthGuard] }
// ];
export const routes: Routes = [
  { path: 'dash', component: DashboardComponent },
  {
      path: 'register', component: UserComponent,
      children: [{ path: '', component: RegisterComponent }]
  },
  {
      path: 'login', component: UserComponent,
      children: [{ path: '', component: LoginComponent }]
  },
  { path : '', redirectTo:'/login', pathMatch : 'full'}
  
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
