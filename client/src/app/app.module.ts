import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderInfoComponent } from './components/header-info/header-info.component';
import { HeaderDetailsComponent } from './components/header-details/header-details.component';
import { PropertyInfoComponent } from './components/property-info/property-info.component';
import { PropertyForSaleComponent } from './components/property-for-sale/property-for-sale.component';
import { HeaderPropertyForSaleComponent } from './components/header-property-for-sale/header-property-for-sale.component';
import { HeaderAvailableBidItemComponent } from './components/header-available-bid-item/header-available-bid-item.component';
import { HttpClientModule } from '@angular/common/http';
import { CurrencyPipe } from '@angular/common';
import { PropertyDetailsComponent } from './pages/property-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    PropertyDetailsComponent,
    HeaderInfoComponent,
    HeaderDetailsComponent,
    PropertyInfoComponent,
    PropertyForSaleComponent,
    HeaderPropertyForSaleComponent,
    HeaderAvailableBidItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [CurrencyPipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
