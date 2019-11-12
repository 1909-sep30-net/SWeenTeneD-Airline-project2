import { Component, OnInit } from '@angular/core';
import flight from '../flight';
import { flightService } from '../flight.service';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class flightComponent implements OnInit {

  public bookfight = [];
  show() {
    return this.bfapi.getItems().subscribe(data => {
      this.bookfight = data
    })
  }

  constructor(private bfapi: flightService) { }

 

  ngOnInit() {
  }

}
