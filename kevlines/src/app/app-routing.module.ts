import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {RegisterComponent} from '../app/shared/components/register/register.component';
import {CheckinComponent} from './shared/components/checkin/checkin.component';
import { ProfileComponent } from '../app/shared/components/profile/profile.component';
import {BookflightComponent} from './shared/components/bookflight/bookflight.component';         
import { AuthGuard } from './shared/guards/auth.guard';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from './shared/services/interceptor.service';
import { ExternalApiComponent } from  '../app/shared/components/external-api/external-api.component';
import { FlightstatusComponent } from './shared/components/flightstatus/flightstatus.component';

const routes: Routes = [
  { path: '', component: RegisterComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},
  { path:'bookflight',component: BookflightComponent},
  { path:'flightstatus',component: FlightstatusComponent, canActivate: [AuthGuard]},
  { path:'checkin',component: CheckinComponent}, 
  { path: 'external-api', component: ExternalApiComponent, canActivate: [AuthGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: InterceptorService,
    multi: true
  }]
})
export class AppRoutingModule { }
