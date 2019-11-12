import { Component, OnInit } from '@angular/core';
import BookFlight from '../bookflight';
import { BookflightService } from '../bookflight.service';

@Component({
  selector: 'app-bookflight',
  templateUrl: './bookflight.component.html',
  styleUrls: ['./bookflight.component.css']
})
export class BookflightComponent implements OnInit {

  public bookfight = [];
  show() {
    return this.bfapi.getItems().subscribe(data => {
      this.bookfight = data
    })
  }

  constructor(private bfapi: BookflightService) { }

 

  ngOnInit() {
  }

}
