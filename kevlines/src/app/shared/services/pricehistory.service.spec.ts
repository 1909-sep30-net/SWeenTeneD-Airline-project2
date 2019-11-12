import { TestBed } from '@angular/core/testing';

import { PricehistoryService } from './pricehistory.service';

describe('PricehistoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PricehistoryService = TestBed.get(PricehistoryService);
    expect(service).toBeTruthy();
  });
});
