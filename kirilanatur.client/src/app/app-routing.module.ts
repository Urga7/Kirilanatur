import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DataFlowComponent } from "./data-flow/data-flow.component";
import { WeatherForecastComponent } from "./weather-forecast/weather-forecast.component";
import {HomeComponent} from "./home/home.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'weatherForecast', component: WeatherForecastComponent },
  { path: 'dataFlow', component: DataFlowComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/home'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
