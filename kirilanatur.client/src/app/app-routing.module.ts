import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DataFlowComponent } from "./components/data-flow/data-flow.component";
import { HomeComponent } from "./components/home/home.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'dataFlow', component: DataFlowComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/home'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
