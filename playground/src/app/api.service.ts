import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import Customer from './customer';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  getItems(): Promise<Customer> {
    const url = `${environment.BaseUrl}/api/customer/`;
    return this.httpClient.get<Customer>(url).toPromise();
  }
}
