import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Cust2Component } from './cust2.component';

describe('Cust2Component', () => {
  let component: Cust2Component;
  let fixture: ComponentFixture<Cust2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Cust2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Cust2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
