import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiClient, HttpRequestMethodType } from '../api/api-client';
import { GetProductPriceId, ProductPriceId } from './product-price-id';
import { ShoppingBag } from './shopping-bag.service';

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
  private readonly httpClient = inject(HttpClient)
  private readonly apiClient = new ApiClient(this.httpClient, 'http://localhost:5122/api/')
  private readonly shoppingBag = inject(ShoppingBag)

  public async purchase() {
    const shoppingBagItems = this.shoppingBag.items()
    const orderItems: CheckoutItem[] = shoppingBagItems.map(it =>
      ({priceId: GetProductPriceId(it.productId, it.size), quantity: it.quantity}))

    const request: CheckoutRequest = { items: orderItems }

    const response = await this.apiClient.callApi<CheckoutResponse>(
      "checkout", undefined, HttpRequestMethodType.POST, request)

    console.log(response)
    window.location.href = response.data.url
  }
}
