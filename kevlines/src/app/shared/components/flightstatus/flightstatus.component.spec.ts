import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightstatusComponent } from './flightstatus.component';

describe('FlightstatusComponent', () => {
  let component: FlightstatusComponent;
  let fixture: ComponentFixture<FlightstatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlightstatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightstatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
