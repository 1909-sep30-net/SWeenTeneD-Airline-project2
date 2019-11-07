import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { cust } from './cust';

@Injectable({
  providedIn: 'root'
})
export class InMemDataService implements InMemoryDbService{

    createDb() {
      const customers = [
        {id: 11, name: 'Tri'},
        {id: 12, name: 'Dom'},
        {id: 13, name: 'Sam'},
        {id: 14, name: 'BuryMe'}
      ];
      return {customers};
    }
  
    genId(customers: cust[]): number {
      return customers.length > 0 ? Math.max(...customers.map(cust => cust.id)) + 1 : 11;
    }
}
