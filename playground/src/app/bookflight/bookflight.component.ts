import { Component, OnInit } from '@angular/core';
import Flight from '../Flight';
import ticket from '../ticket';
import { BookflightService } from '../Flight.service';

@Component({
  selector: 'app-bookflight',
  templateUrl: './bookflight.component.html',
  styleUrls: ['./bookflight.component.css']
})
export class BookflightComponent implements OnInit {

  public flight = [];

  constructor(private bfapi: BookflightService) { }

  // showflight() {
  //   return this.bfapi.getItems()
  //   .then(item => this.items = item);
  // }

  showflight() {
    return this.bfapi.getItems().subscribe(data => {
      this.flight = data
    })
  }

  buyticket(flightID) {
    console.log(flightID);
  }

  ngOnInit() {
    return this.bfapi.getItems().subscribe(data => {
      this.flight = data
    })
  }

}
