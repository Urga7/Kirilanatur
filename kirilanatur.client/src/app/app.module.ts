import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DataFlowComponent } from './data-flow/data-flow.component';
import { NavbarComponent } from './navbar/navbar.component';
import { WeatherForecastComponent } from './weather-forecast/weather-forecast.component';
import { HomeComponent } from './home/home.component';
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    DataFlowComponent,
    NavbarComponent,
    WeatherForecastComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
