import {Component, inject, input} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-card',
  imports: [

  ],
  templateUrl: './product-card.html',
})
export class ProductCard {
  readonly id = input.required<number>()
  protected readonly router = inject(Router);

  async goToProduct(id: number) {
    await this.router.navigate(['shop/product/' + id]);
  }
}
