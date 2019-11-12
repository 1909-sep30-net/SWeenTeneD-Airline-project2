import { Component, OnInit } from '@angular/core';
import Customer from '../customer';
import { CustomerApiService } from '../customerapi.service';

@Component({
  selector: 'app-cust2',
  templateUrl: './cust2.component.html',
  styleUrls: ['./cust2.component.css']
})
export class Cust2Component implements OnInit {
 // items: Customer[] = null;
 public customerr = [];
  show() {
    return this.custApi.getItems().subscribe(data => {
      this.customerr = data
    })
  }

  
  // show() {
  //   return this.custApi.getItems()
  //   .then(item => this.items = item);
  // }


<<<<<<< HEAD
  constructor(private custApi: CustomerApiService) { }
=======
  constructor(private custApi: ApiService) { }
>>>>>>> master

  ngOnInit() {
    //this.custApi.getItems().subscribe(data => this.customerr = data)
  }

}
