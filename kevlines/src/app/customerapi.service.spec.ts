import { TestBed } from '@angular/core/testing';

import { CustomerApiService } from './customerapi.service';

describe('ApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CustomerApiService = TestBed.get(CustomerApiService);
    expect(service).toBeTruthy();
  });
});
