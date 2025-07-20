import {Component, inject} from '@angular/core';
import {ShoppingBag} from '../../../common/shopping-bag.service';

@Component({
  selector: 'app-shopping-bag-preview',
  imports: [],
  templateUrl: './shopping-bag-preview.html'
})
export class ShoppingBagPreview {
  private shoppingBag = inject(ShoppingBag)
}
