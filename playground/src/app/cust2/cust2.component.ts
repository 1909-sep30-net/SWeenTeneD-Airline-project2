import { Component, OnInit } from '@angular/core';
import Customer from '../customer';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-cust2',
  templateUrl: './cust2.component.html',
  styleUrls: ['./cust2.component.css']
})
export class Cust2Component implements OnInit {
  items: Customer[] = null;

  show(): void {
    this.custApi.getItems()
    .then(item => this.items = item);
  }
  

  constructor(private custApi: ApiService) { }

  ngOnInit() {
  }

}
