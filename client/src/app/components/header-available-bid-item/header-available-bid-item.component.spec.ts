import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderAvailableBidItemComponent } from './header-available-bid-item.component';

describe('HeaderAvailableBidItemComponent', () => {
  let component: HeaderAvailableBidItemComponent;
  let fixture: ComponentFixture<HeaderAvailableBidItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeaderAvailableBidItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderAvailableBidItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
