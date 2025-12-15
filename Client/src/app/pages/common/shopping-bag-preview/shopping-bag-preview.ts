import {Component, inject} from '@angular/core';
import {ShoppingBag} from '../../../common/shopping-bag.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shopping-bag-preview',
  imports: [],
  templateUrl: './shopping-bag-preview.html'
})
export class ShoppingBagPreview {
  private router = inject(Router)
  protected shoppingBag = inject(ShoppingBag)

  protected toCheckout() {
    void this.router.navigate(['checkout'])
  }
}
