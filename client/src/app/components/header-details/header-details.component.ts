import { CurrencyPipe } from '@angular/common';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { BidItem } from 'src/app/models/bidItem';
@Component({
  selector: 'app-header-details',
  templateUrl: './header-details.component.html',
  styleUrls: ['./header-details.component.scss']
})
export class HeaderDetailsComponent implements OnChanges {

  @Input() selectedBid: BidItem = {} as BidItem;

  marketValueFormatted: string | null = "";
  currentBidFormatted: string | null = "";

  constructor(private currencyPipe:CurrencyPipe) { }

  ngOnChanges(changes: SimpleChanges): void {

    if(!this.selectedBid) return;

    this.marketValueFormatted = this.currencyPipe.transform(
        this.selectedBid.marketValue,
        'USD',
        'symbol',
        "1.0-2");

    this.currentBidFormatted = this.currencyPipe.transform(
      this.selectedBid.currentBid,
      'USD',
      'symbol',
      "1.0-2");
  }

}
