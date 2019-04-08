import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AirPlaneFormComponent } from './airplane-form.component';

describe('AirPlaneFormComponent', () => {
  let component: AirPlaneFormComponent;
  let fixture: ComponentFixture<AirPlaneFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AirPlaneFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AirPlaneFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
