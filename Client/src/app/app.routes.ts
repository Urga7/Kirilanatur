import { Routes } from '@angular/router';
import {Home} from './pages/home/home';
import {Shop} from './pages/shop/shop';

export const routes: Routes = [
  { path: 'home', component: Home },
  { path: 'shop', component: Shop },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
];
