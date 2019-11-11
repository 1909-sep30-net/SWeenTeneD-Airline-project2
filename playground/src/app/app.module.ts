import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

//import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemDataService } from './in-mem-data.service';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { MessageComponent } from './message/message.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CustomerSearchComponent } from './customer-search/customer-search.component';
import { Cust2Component } from './cust2/cust2.component';
import { BookflightComponent } from './bookflight/bookflight.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    CustomerDetailComponent,
    MessageComponent,
    DashboardComponent,
    CustomerSearchComponent,
    Cust2Component,
    BookflightComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,

    // HttpClientInMemoryWebApiModule.forRoot(
    //   InMemDataService, { dataEncapsulation: false}
    // )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
