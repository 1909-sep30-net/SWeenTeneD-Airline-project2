import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import Customer from '../models/customer'; 
import {environment} from '../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }



  insertCustomer(customer: Customer): Promise<Customer> {
    let url = `${environment.BaseUrl}/api/Customer`;
    return this.httpClient.post<Customer>(url, customer).toPromise()
  }

  /*
  insertCustomer(customer: Customer): Observable<Customer> {
    let url = `${environment.kevApiBaseUrl}/api/Customer`;
    return this.httpClient.post<Customer>(url, customer)
  }
*/

}
