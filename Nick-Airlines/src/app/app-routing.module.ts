import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {RegisterComponent } from './register/register.component';
import {LoginComponent } from './login/login.component';
import {HomeComponent } from  './home/home.component';
import {HeaderComponent} from './header/header.component';
import {PagenotfoundComponent } from './pagenotfound/pagenotfound.component';


const routes: Routes = [
{path:'', component:RegisterComponent },
{path:'login',component: LoginComponent },
{path:'home', component: HomeComponent},
{path:'**', component: PagenotfoundComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
