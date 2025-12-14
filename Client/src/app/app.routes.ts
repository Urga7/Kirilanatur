import {Routes} from '@angular/router';
import {Home} from './pages/home/home';
import {Shop} from './pages/shop/shop';
import {Product} from './pages/common/product/product';

export const routes: Routes = [
  {path: 'home', component: Home},
  {path: 'products/:name', component: Product},
  {path: 'products', component: Shop},
  {path: '', redirectTo: 'home', pathMatch: 'full'},
];
