import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from '../../components/navbar/navbar.component';
import FlightStatus from '../../models/flightstatus';
import {FlightstatusService} from '../../services/flightstatus.service';

@Component({
  selector: 'app-flightstatus',
  templateUrl: './flightstatus.component.html',
  styleUrls: ['./flightstatus.component.css']
})
export class FlightstatusComponent implements OnInit {

  constructor(private _flightStatus: FlightstatusService) { }
  public fs = []

show(){
  return this._flightStatus.getItems().subscribe(data => {
    this.fs = data;
  })
}


  ngOnInit() {

    this._flightStatus.getItems().subscribe(data =>{
      this.fs = data
    })
  }

}
