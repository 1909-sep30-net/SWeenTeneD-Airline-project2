import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import IHistoryModel from '../models/IHistoryModel'
@Injectable({
  providedIn: 'root'
})
export class PricehistoryService {

  constructor(private http:HttpClient) { }

  //url = 'http://api.travelpayouts.com/v2/prices/latest?currency=usd&period_type=year&page=1&limit=30&show_to_affiliates=true&sorting=price&trip_class=0&token=be7446d916a179506429ff3b30a98b30'
 // recentTickets(): Observable<any>{
  //  return this.http.get('http://api.travelpayouts.com/v2/prices/latest?currency=usd&period_type=year&page=1&limit=30&show_to_affiliates=true&sorting=price&trip_class=0&token=be7446d916a179506429ff3b30a98b30');
 // }


  

 

  getItems(): Promise<IHistoryModel[]> {
    const url = 'http://api.travelpayouts.com/v2/prices/latest?currency=usd&period_type=year&page=1&limit=30&show_to_affiliates=true&sorting=price&trip_class=0&token=be7446d916a179506429ff3b30a98b30';
    return this.http.get<IHistoryModel[]>(url).toPromise();
  }
}
