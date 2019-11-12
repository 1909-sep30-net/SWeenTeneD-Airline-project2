import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.prod';
import Customer from  './customer';
import { Observable } from 'rxjs';
import Flight from './Flight';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
   url = `${environment.BaseUrl}/api/customer`;

  constructor(private httpClient: HttpClient) { }

  getItems(): Observable<Customer[]> {
    
    return this.httpClient.get<Customer[]>('https://sweentened.azurewebsites.net/api/customer');
  }

  // getItems(): Promise<Customer[]> {
  //   const url = `${environment.BaseUrl}/api/customer`;
  //   return this.httpClient.get<Customer[]>(url).toPromise();
  // }
}
