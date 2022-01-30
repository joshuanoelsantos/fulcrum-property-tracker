using AutoMapper;
using PropertyRental.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyRental.API
{
    public record BidGetTotalResponse
    {
        public TotalData Outbid { get; init; }
        public TotalData Active { get; init; }
        public TotalData Winning { get; init; }

        public BidGetTotalResponse(List<BidWithPropertyAndHighestBid> bids)
        {
            Active = new TotalData(
                Count: bids.Count,
                Amount: bids.Sum(x => x.CurrentBid.Amount));

            List<BidWithPropertyAndHighestBid> outbids = bids.Where(x => !x.IsWinning).ToList();
            Outbid = new TotalData(
                Count: outbids.Count,
                Amount: outbids.Sum(x => x.CurrentBid.Amount));

            List<BidWithPropertyAndHighestBid> winningBids = bids.Where(x => x.IsWinning).ToList();
            Winning = new TotalData(
                Count: winningBids.Count,
                Amount: winningBids.Sum(x => x.CurrentBid.Amount));
        }
    }

    public record TotalData(decimal Count, decimal Amount);

}