import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DataFlowComponent } from "./components/data-flow/data-flow.component";
import { HomeComponent } from "./components/home/home.component";
import { SandalsComponent } from "./components/sandals/sandals.component";
import { AdminComponent } from "./components/admin/admin.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'dataFlow', component: DataFlowComponent },
  { path: 'sandals', component: SandalsComponent },
  { path: 'admin', component: AdminComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/home'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
