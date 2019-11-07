import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { catchError, map, tap} from 'rxjs/operators';

import { cust } from './cust';
import { MessageService } from './message.service';

import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private custUrl = 'api/customers';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  }

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  getCustomers(): Observable<cust[]> {
    return this.http.get<cust[]>(this.custUrl)
        .pipe(
          tap(_ => this.log('fetched customers')),
          catchError(this.handleError<cust[]>('getCustomers', []))
        );
  }

  getCustNo404<Data>(id: number): Observable<cust> {
    const url = '${this.custUrl}/?id=${id}';
    return this.http.get<cust[]>(url)
        .pipe(
          map(cust => cust[0]),
          tap(c => {
            const outcome = c ? 'fetched' : 'did not find';
            this.log('${outcome} customer id= ${id}');
          }),
          catchError(this.handleError<cust>('getCust id=${id}'))
        );
  }

  getCustomer(id: number): Observable<cust> {
    const url = `${this.custUrl}/${id}`;
    return this.http.get<cust>(url).pipe(
      tap(_ => this.log(`fetched hero id=${id}`)),
      catchError(this.handleError<cust>(`getCust id=${id}`))
    );
  }

  searchCustomers(term: string): Observable<cust[]> {
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return of([]);
    }
    return this.http.get<cust[]>(`${this.custUrl}/?name=${term}`).pipe(
      tap(_ => this.log(`found customers matching "${term}"`)),
      catchError(this.handleError<cust[]>('searchCustomers', []))
    );
  }

  addCust (cust: cust): Observable<cust> {
    return this.http.post<cust>(this.custUrl, cust, this.httpOptions).pipe(
      tap((newCust: cust) => this.log(`added customer w/ id=${newCust.id}`)),
      catchError(this.handleError<cust>('addCust'))
    );
  }

  /** DELETE: delete the hero from the server */
  deleteCust (cust: cust | number): Observable<cust> {
    const id = typeof cust === 'number' ? cust : cust.id;
    const url = `${this.custUrl}/${id}`;

    return this.http.delete<cust>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted customer id=${id}`)),
      catchError(this.handleError<cust>('deleteCust'))
    );
  }

  /** PUT: update the hero on the server */
  updateCust (cust: cust): Observable<any> {
    return this.http.put(this.custUrl, cust, this.httpOptions).pipe(
      tap(_ => this.log(`updated customer id=${cust.id}`)),
      catchError(this.handleError<any>('updateCust'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a HeroService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`CustomerService: ${message}`);
  }
}
