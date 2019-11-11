import { Component, OnInit } from '@angular/core';
import BookFlight from '../bookflight';
import { BookflightService } from '../bookflight.service';

@Component({
  selector: 'app-bookflight',
  templateUrl: './bookflight.component.html',
  styleUrls: ['./bookflight.component.css']
})
export class BookflightComponent implements OnInit {

  items: BookFlight[];

  constructor(private bfapi: BookflightService) { }

  showflight() {
    return this.bfapi.getItems()
    .then(item => this.items = item);
  }

  ngOnInit() {
  }

}
