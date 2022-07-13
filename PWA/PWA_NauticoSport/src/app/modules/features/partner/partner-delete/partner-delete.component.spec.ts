import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartnerDeleteComponent } from './partner-delete.component';

describe('PartnerDeleteComponent', () => {
  let component: PartnerDeleteComponent;
  let fixture: ComponentFixture<PartnerDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PartnerDeleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PartnerDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
