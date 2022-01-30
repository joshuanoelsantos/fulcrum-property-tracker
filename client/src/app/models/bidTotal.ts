export interface BidTotal {
    outbid: Total;
    active: Total;
    winning: Total;
}

interface Total {
    count: number;
    amount: number;
}