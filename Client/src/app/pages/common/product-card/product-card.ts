import {Component, inject, input} from '@angular/core';
import { ProductWithPrices } from '../../../common/product-repository';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-card',
  imports: [],
  templateUrl: './product-card.html',
})
export class ProductCard {
  readonly product = input.required<ProductWithPrices>()
  protected readonly router = inject(Router)

  async goToProduct() {
    await this.router.navigate(['products/' + this.product().name])
  }
}
