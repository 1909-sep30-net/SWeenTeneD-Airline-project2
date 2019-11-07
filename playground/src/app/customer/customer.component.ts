import { Component, OnInit } from '@angular/core';
import { cust } from '../cust';
import { CustomerService } from '../customer.service'

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

    custs: cust[];
    
    constructor(private custService: CustomerService) { }

    ngOnInit() {
      this.getCustomers();
    }

    getCustomers(): void {
      this.custService.getCustomers()
        .subscribe(custs => this.custs = custs);
    }

  add(name: string): void {
    name = name.trim();
    if(!name) {return;}
    this.custService.addCust({name} as cust)
        .subscribe(cust => {
          this.custs.push(cust);
        });
  }

  delete(cust: cust): void {
    this.custs = this.custs.filter(c => c !== cust);
    this.custService.deleteCust(cust).subscribe();
  }

}
