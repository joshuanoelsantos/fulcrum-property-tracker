import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BidItem } from '../models/bidItem';
import { BidListItem } from '../models/bidListItem';
import { BidTotal } from '../models/bidTotal';

@Injectable({
    providedIn: 'root',
})
export class BidService {

    baseUrl: string = "https://localhost:5001/api/bids";

    constructor(protected httpClient: HttpClient) {
    }

    list(): Observable<BidListItem[]> {
        return this.httpClient.get<BidListItem[]>(`${this.baseUrl}`);
    }

    get(id: string | null): Observable<BidItem> {
        return this.httpClient.get<BidItem>(`${this.baseUrl}/${id}`);
    }

    getTotal(): Observable<BidTotal> {
        return this.httpClient.get<BidTotal>(`${this.baseUrl}/total`);
    }
}