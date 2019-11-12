import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.prod';
import Flight from  './flight';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class flightService {

  constructor(private httpClient: HttpClient) { }

  url = `${environment.BaseUrl}/api/airport`;

  getItems(): Observable<Flight[]> {
    
    return this.httpClient.get<Flight[]>(this.url);
  }
}
