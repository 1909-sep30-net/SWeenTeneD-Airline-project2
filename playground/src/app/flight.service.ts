import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.prod';
<<<<<<< HEAD
import Flight from  './Flight';
=======
import Flight from  './flight';
>>>>>>> master
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
<<<<<<< HEAD
export class BookflightService {

  constructor(private httpClient: HttpClient) { }

  url = `${environment.BaseUrl}/api/flight`;
=======
export class flightService {

  constructor(private httpClient: HttpClient) { }

  url = `${environment.BaseUrl}/api/airport`;
>>>>>>> master

  getItems(): Observable<Flight[]> {
    
    return this.httpClient.get<Flight[]>(this.url);
  }
}
