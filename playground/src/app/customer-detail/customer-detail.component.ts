import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { cust } from '../cust';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {
  @Input() cust: cust;

  constructor(
    private route: ActivatedRoute,
    private custService: CustomerService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getCust();
  }

  getCust(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.custService.getCustomer(id)
      .subscribe(cust => this.cust = cust);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    this.custService.updateCust(this.cust)
        .subscribe(() => this.goBack());
  }
}
