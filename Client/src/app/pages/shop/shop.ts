import { Component, inject, OnInit, signal } from '@angular/core';
import {ProductCard} from '../common/product-card/product-card';
import { ProductRepository, ProductWithPrices } from '../../common/product-repository';

@Component({
  selector: 'app-shop',
  imports: [
    ProductCard
  ],
  templateUrl: './shop.html',
})
export class Shop implements OnInit {
  private readonly productRepository = inject(ProductRepository)
  protected readonly productsWithPrices = signal<ProductWithPrices[]>([])

  async ngOnInit() {
    const productsWithPrices = await this.productRepository.productsWithPrices()
    this.productsWithPrices.set(productsWithPrices)
  }
}
