import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { PropertyDetailsComponent } from './pages/property-detail.component';

// const routes: Routes = [];

const routes: Routes = [
  { path: '', component: PropertyDetailsComponent },
  { path: ':id', component: PropertyDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
