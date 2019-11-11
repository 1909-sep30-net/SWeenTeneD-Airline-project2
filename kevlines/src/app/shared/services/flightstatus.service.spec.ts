import { TestBed } from '@angular/core/testing';

import { FlightstatusService } from './flightstatus.service';

describe('FlightstatusService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FlightstatusService = TestBed.get(FlightstatusService);
    expect(service).toBeTruthy();
  });
});
