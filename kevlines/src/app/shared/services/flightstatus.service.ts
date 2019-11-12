import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {environment} from '../../../environments/environment';
import FlightStatus  from '../../shared/models/flightstatus';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightstatusService {

  constructor(private http:HttpClient) { }


  getItems(): Observable<FlightStatus[]> {

    //const url = `${environment.kevApiBaseUrl}/api/flight`;
    return this.http.get<FlightStatus[]>('https://sweentened.azurewebsites.net/api/flight');
    
  }



  





}
