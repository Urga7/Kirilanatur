import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductData {
  public imageUrl(productId: string, imageId: string = 'a') {
    return `assets/images/products/product-${productId}${imageId}.jpg`
  }

  public imageAlt(productId: string, imageId: string = 'a') {
    return `product-${productId}${imageId}`
  }

  public productName(productId: string) {
    return `KI70${productId}`
  }
}
