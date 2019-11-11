import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from '../app/shared/components/register/register.component';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { ProfileComponent } from './shared/components/profile/profile.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MaterialModule} from './module/material/material.module';
import { LoginComponent } from '../app/shared/components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { ExternalApiComponent } from './shared/components/external-api/external-api.component';
import {FormControl, FormsModule} from '@angular/forms/';
import { CustomerComponent } from './shared/components/customer/customer.component';
import { BookflightComponent } from './shared/components/bookflight/bookflight.component';
import { CheckinComponent} from './shared/components/checkin/checkin.component'

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ProfileComponent,
    RegisterComponent,
    NavbarComponent,
    LoginComponent,
    ExternalApiComponent,
    CustomerComponent,
    BookflightComponent,
    CheckinComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
