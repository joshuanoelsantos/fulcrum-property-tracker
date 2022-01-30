import { Component, Input } from '@angular/core';
import { BidTotal } from 'src/app/models/bidTotal';
import { BidListItem } from '../../models/bidListItem';
import { BidService } from '../../services/bid.service';

@Component({
  selector: 'app-property-info',
  templateUrl: './property-info.component.html',
  styleUrls: ['./property-info.component.scss']
})
export class PropertyInfoComponent {

  @Input() bids: BidListItem[] = [];
  @Input() bidTotals: BidTotal = {} as BidTotal;

  constructor(
    private bidService: BidService) { }

}
