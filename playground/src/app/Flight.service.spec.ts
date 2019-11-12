import { TestBed } from '@angular/core/testing';

import { flightService } from './flight.service';

describe('BookflightService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: flightService = TestBed.get(flightService);
    expect(service).toBeTruthy();
  });
});
