import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartnerEliminateComponent } from './partner-eliminate.component';

describe('PartnerEliminateComponent', () => {
  let component: PartnerEliminateComponent;
  let fixture: ComponentFixture<PartnerEliminateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PartnerEliminateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PartnerEliminateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
