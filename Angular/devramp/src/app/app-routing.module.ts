import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { CalculationDetailsComponent } from './calculation-details/calculation-details.component';
import { CalculationDetailComponent } from './calculation-details/calculation-detail/calculation-detail.component';

const routes: Routes = [

  { path: 'home', component: HomeComponent },
  { path: 'calculation-details', component: CalculationDetailsComponent },
  { path: 'calculation-details/item', component: CalculationDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
