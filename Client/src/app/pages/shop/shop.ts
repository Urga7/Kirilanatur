import { Component } from '@angular/core';
import {ProductCard} from '../common/product-card/product-card';

@Component({
  selector: 'app-shop',
  imports: [
    ProductCard
  ],
  templateUrl: './shop.html',
})
export class Shop {

}
