import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CustomerComponent } from './customer/customer.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { BookflightComponent } from './bookflight/bookflight.component';


const routes: Routes = [
  {path: 'cust', component: CustomerComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'detail/:id', component: CustomerDetailComponent},
  {path: 'bookflight', component: BookflightComponent},
  {path: '', redirectTo: '/dashboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
