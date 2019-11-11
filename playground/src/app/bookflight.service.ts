import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.prod';
import BookFlight from  './bookflight';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookflightService {

  constructor(private httpClient: HttpClient) { }

  url = `${environment.BaseUrl}/api/airport`;

  getItems(): Observable<BookFlight[]> {
    
    return this.httpClient.get<BookFlight[]>(this.url);
  }
}
