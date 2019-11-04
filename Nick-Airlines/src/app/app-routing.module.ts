import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {RegisterComponent } from './register/register.component';
import {LoginComponent } from './login/login.component';
import {HeaderComponent} from './header/header.component';
import {PagenotfoundComponent } from './pagenotfound/pagenotfound.component';


const routes: Routes = [
{path:'', component:RegisterComponent },
{path:'login',component: LoginComponent },
{path:'header', component: HeaderComponent},
{path:'**', component: PagenotfoundComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
