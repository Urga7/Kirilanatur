import {Component, computed, inject, OnInit, signal} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Svg} from '../svg/svg';

@Component({
  selector: 'app-product',
  imports: [
    Svg
  ],
  templateUrl: './product.html',
})
export class Product implements OnInit {
  protected readonly route = inject(ActivatedRoute);
  protected productId: string | null = null;
  protected readonly selectedImageIdentifier = signal('a')
  protected readonly imageUrl = computed(() => {
    return `assets/images/products/product-${this.productId}${this.selectedImageIdentifier()}.jpg`
  })
  protected readonly imageUrlAlt = computed(() => {
    return `product-${this.productId}${this.selectedImageIdentifier()}`
  })

  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get('id');
  }
}
