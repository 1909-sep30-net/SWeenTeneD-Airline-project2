import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.prod';
import ticket from  './ticket';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private httpClient: HttpClient) { }

  url = `${environment.BaseUrl}/api/flightTicket`;

  addItem(item: ticket) {
    const url = `${environment.BaseUrl}/api/flightTicket`;
    return this.httpClient.post<ticket>(url, item).toPromise();
  }
}
