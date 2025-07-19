import {Component, computed, inject, OnInit, signal} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Svg} from '../svg/svg';

@Component({
  selector: 'app-product',
  imports: [Svg],
  templateUrl: './product.html',
})
export class Product implements OnInit {
  protected readonly route = inject(ActivatedRoute);
  protected productId: string | null = null;
  protected readonly imageIdentifiers = ['a', 'b', 'c', 'd'];
  protected readonly selectedImageIdentifier = signal('a')
  protected readonly availableImageIdentifiers = computed(() => {
    return this.imageIdentifiers.filter(identifier => identifier !== this.selectedImageIdentifier());
  })
  protected readonly selectedImageUrl = computed(() => {
    return `assets/images/products/product-${this.productId}${this.selectedImageIdentifier()}.jpg`
  })
  protected readonly selectedImageAlt = computed(() => {
    return `product-${this.productId}${this.selectedImageIdentifier()}`
  })

  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get('id');
  }

  protected imageUrl(identifier: string) {
    return `assets/images/products/product-${this.productId}${identifier}.jpg`
  }

  protected imageAlt(identifier: string) {
    return `product-${this.productId}${identifier}`
  }
}
