import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderPropertyForSaleComponent } from './header-property-for-sale.component';

describe('HeaderPropertyForSaleComponent', () => {
  let component: HeaderPropertyForSaleComponent;
  let fixture: ComponentFixture<HeaderPropertyForSaleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeaderPropertyForSaleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderPropertyForSaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
