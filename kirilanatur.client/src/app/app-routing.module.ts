import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DataFlowComponent } from "./components/data-flow/data-flow.component";
import { HomeComponent } from "./components/home/home.component";
import { SandalsComponent } from "./components/sandals/sandals.component";
import { AdminComponent } from "./components/admin/admin.component";
import { RegisterComponent } from "./components/authentication/register/register.component";
import { LoginComponent } from "./components/authentication/login/login.component";
import { ShoppingCartComponent } from "./components/shopping-cart/shopping-cart.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'dataFlow', component: DataFlowComponent },
  { path: 'sandals', component: SandalsComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'shopping-cart', component: ShoppingCartComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/home'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
