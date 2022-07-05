import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartnerModifyComponent } from './partner-modify.component';

describe('PartnerModifyComponent', () => {
  let component: PartnerModifyComponent;
  let fixture: ComponentFixture<PartnerModifyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PartnerModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PartnerModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
