import { Component, Input, OnInit } from '@angular/core';
import { BidItem } from 'src/app/models/bidItem';

@Component({
  selector: 'app-property-for-sale',
  templateUrl: './property-for-sale.component.html',
  styleUrls: ['./property-for-sale.component.scss']
})
export class PropertyForSaleComponent {

  @Input() selectedBid: BidItem = {} as BidItem;
}
