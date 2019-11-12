import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.prod';
import Flight from  './Flight';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookflightService {

  constructor(private httpClient: HttpClient) { }

  url = `${environment.BaseUrl}/api/flight`;

  getItems(): Observable<Flight[]> {
    
    return this.httpClient.get<Flight[]>(this.url);
  }
}
