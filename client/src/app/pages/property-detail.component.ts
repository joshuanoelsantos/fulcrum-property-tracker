import { Component } from '@angular/core';

import { ActivatedRoute, NavigationStart, ParamMap, Params, Router } from '@angular/router';
import { BidItem } from '../models/bidItem';
import { BidListItem } from '../models/bidListItem';
import { BidTotal } from '../models/bidTotal';
import { BidService } from '../services/bid.service';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.scss']
})
export class PropertyDetailsComponent {
    imageSrc = "assets/images/property.png";

    bids: BidListItem[] = [];
    selectedBid: BidItem = {} as BidItem;
    bidTotals: BidTotal = {} as BidTotal;

    constructor(
        private route: ActivatedRoute,
        private bidService: BidService) { }

    ngOnInit(): void {

        this.bidService.list().subscribe((data) => {
            this.bids = data;
        });

        this.bidService.getTotal().subscribe((data) => {
            this.bidTotals = data;
        });

        this.route.paramMap.subscribe((params: ParamMap) => {

            const bidId: string = params.get('id') ?? "61f682353155b36a412adb14";

            this.bidService.get(bidId).subscribe((data) => {
                this.selectedBid = data;
            });
        })
    }
}
