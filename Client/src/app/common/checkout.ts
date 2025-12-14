import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiClient, HttpRequestMethodType } from '../api/api-client';
import { GetProductPriceId, ProductPriceId } from './product-price-id';
import { ShoppingBag } from './shopping-bag.service';
import { KirilanaturApi } from '../api/kirilanatur/kirilanatur-api';

export interface CheckoutRequest {
  items: CheckoutItem[]
}

export interface CheckoutItem {
  priceId: string
  quantity: number
}

export interface CheckoutResponse {
  url: string
}

@Injectable({
  providedIn: 'root'
})
export class Checkout {
  private readonly kirilanaturApi = inject(KirilanaturApi)
  private readonly shoppingBag = inject(ShoppingBag)

  public async purchase() {
    const shoppingBagItems = this.shoppingBag.items()
    const orderItems: CheckoutItem[] = shoppingBagItems.map(it =>
      ({priceId: GetProductPriceId(it.productId, it.size), quantity: it.quantity}))

    const request: CheckoutRequest = { items: orderItems }
    const response = await this.kirilanaturApi.post.checkout(request)

    console.log(response)
    window.location.href = response.data.url
  }
}
