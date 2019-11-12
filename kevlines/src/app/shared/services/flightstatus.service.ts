import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {environment} from '../../../environments/environment';
import flightstatus from '../../shared/models/flightstatus';

@Injectable({
  providedIn: 'root'
})
export class FlightstatusService {

  constructor(private http:HttpClient) { }


  getItems(): Promise<flightstatus[]> {
    const url = `${environment.kevApiBaseUrl}/api/flight`;
    return this.http.get<flightstatus[]>(url).toPromise();
    
  }



  





}
