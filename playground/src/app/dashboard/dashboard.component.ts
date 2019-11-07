import { Component, OnInit } from '@angular/core';
import { cust } from '../cust';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  custs: cust[] = [];

  constructor(private custService: CustomerService) { }

  ngOnInit() {
    this.getCusts();
  }

  getCusts(): void {
    this.custService.getCustomers()
        .subscribe(custs => this.custs = custs.slice(1, 5))
  }

}
