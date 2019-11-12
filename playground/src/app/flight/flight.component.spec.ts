import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { flightComponent } from './flight.component';

describe('BookflightComponent', () => {
  let component: flightComponent;
  let fixture: ComponentFixture<flightComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ flightComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(flightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
