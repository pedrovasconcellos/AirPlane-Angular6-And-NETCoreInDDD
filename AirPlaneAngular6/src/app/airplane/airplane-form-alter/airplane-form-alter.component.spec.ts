import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AirPlaneFormAlterComponent } from './airplane-form-alter.component';

describe('AirPlaneFormAlterComponent', () => {
  let component: AirPlaneFormAlterComponent;
  let fixture: ComponentFixture<AirPlaneFormAlterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AirPlaneFormAlterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AirPlaneFormAlterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
