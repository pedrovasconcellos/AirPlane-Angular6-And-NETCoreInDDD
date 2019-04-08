import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AirPlaneListComponent } from './airplane-list.component';

describe('AirplaneListComponent', () => {
  let component: AirPlaneListComponent;
  let fixture: ComponentFixture<AirPlaneListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AirPlaneListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AirPlaneListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
