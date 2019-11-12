import { TestBed } from '@angular/core/testing';

<<<<<<< HEAD
import { BookflightService } from './Flight.service';
=======
import { flightService } from './flight.service';
>>>>>>> master

describe('BookflightService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
<<<<<<< HEAD
    const service: BookflightService = TestBed.get(BookflightService);
=======
    const service: flightService = TestBed.get(flightService);
>>>>>>> master
    expect(service).toBeTruthy();
  });
});
