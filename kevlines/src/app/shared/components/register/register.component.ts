import { Component, OnInit } from '@angular/core';
import {CustomerService} from '../../services/customer.service';
import Customer from '../../models/customer';
import {NavbarComponent} from '../navbar/navbar.component';
import {HttpClientModule} from '@angular/common/http';
import {PricehistoryService} from '../../services/pricehistory.service';
import IHistoryModel from '../../models/IHistoryModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  items: IHistoryModel[] | null = null;
  
  constructor(private _priceHistoryService: PricehistoryService) { }

  //Hold list of tickets of type IHistoryModel
  listTickets:IHistoryModel[];

  loadItems() {
    return this._priceHistoryService.getItems()
      .then(items => this.items = items);
  }






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
  }







}
