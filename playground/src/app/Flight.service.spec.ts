import { TestBed } from '@angular/core/testing';

import { BookflightService } from './Flight.service';

describe('BookflightService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BookflightService = TestBed.get(BookflightService);
    expect(service).toBeTruthy();
  });
});
