import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-header-available-bid-item',
  templateUrl: './header-available-bid-item.component.html',
  styleUrls: ['./header-available-bid-item.component.scss']
})
export class HeaderAvailableBidItemComponent implements OnInit {
  @Input() address: string;
  @Input() priceIndicator: number;
  @Input() reservedBid: number;

  constructor() {
    this.address = ""
    this.priceIndicator = 0
    this.reservedBid = 0
  }

  ngOnInit(): void {
  }

}
