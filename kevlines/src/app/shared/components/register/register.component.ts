import { Component, OnInit } from '@angular/core';
import {CustomerService} from '../../services/customer.service';
import Customer from '../../models/customer';
import {NavbarComponent} from '../navbar/navbar.component';
import {HttpClientModule} from '@angular/common/http';
import {PricehistoryService} from '../../services/pricehistory.service';
import IHistoryModel from '../../models/IHistoryModel';
import {HttpClient} from '@angular/common/http'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

 // items: IHistoryModel[] | null = null;
  
  constructor(public _priceHistoryService: PricehistoryService) { }

  public phs = []


  






  //Hold list of tickets of type IHistoryModel
 // listTickets:IHistoryModel[];

 





  ngOnInit() {

/*
    this._priceHistoryService.recentTickets().subscribe(
      //Data returned from rest API
      data=>
      {
        // Typecasting api data to our list
        this.listTickets = data;
      }

    )
*/

this._priceHistoryService.getItems().subscribe(data =>{
  this.phs = data
})

}

}


