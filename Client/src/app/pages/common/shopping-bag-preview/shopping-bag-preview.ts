import {Component, inject} from '@angular/core';
import {ShoppingBag} from '../../../common/shopping-bag.service';
import {ProductData} from '../../../common/product-data.service';
import { Checkout } from '../../../common/checkout';

@Component({
  selector: 'app-shopping-bag-preview',
  imports: [],
  templateUrl: './shopping-bag-preview.html'
})
export class ShoppingBagPreview {
  protected shoppingBag = inject(ShoppingBag)
  protected productData = inject(ProductData)

  private checkout = inject(Checkout)

  protected toCheckout() {
    void this.checkout.purchase()
  }
}
