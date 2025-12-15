import {Routes} from '@angular/router';
import {Home} from './pages/home/home';
import {Shop} from './pages/shop/shop';
import {Product} from './pages/common/product/product';
import { SuccessfulPurchase } from './pages/successful-purchase/successful-purchase';
import { Checkout } from './common/checkout';
import { Return } from './common/return';

export const routes: Routes = [
  {path: 'home', component: Home},
  {path: 'products/:name', component: Product},
  {path: 'products', component: Shop},
  {path: 'successful-purchase', component: SuccessfulPurchase},
  {path: 'checkout', component: Checkout},
  {path: 'return', component: Return},
  {path: '', redirectTo: 'home', pathMatch: 'full'},
];
