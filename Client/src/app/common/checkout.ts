import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiClient, HttpRequestMethodType } from '../api/api-client';
import { ProductPrice } from './product-price';

export interface PurchaseSandalRequest {
  priceId: string
  quantity: number
}

export interface PurchaseSandalResponse {
  url: string
}

@Injectable({
  providedIn: 'root'
})
export class Checkout {
  private readonly httpClient = inject(HttpClient)
  private readonly apiClient = new ApiClient(this.httpClient, 'http://localhost:5122/api/')

  public async purchase(productId: number) {
    const request: PurchaseSandalRequest = { priceId: ProductPrice[productId], quantity: 1 }
    const response = await this.apiClient.callApi<PurchaseSandalResponse>(
      "sandals/purchase",
      undefined,
      HttpRequestMethodType.POST,
      request
    )

    console.log(response)
    window.location.href = response.data.url
  }
}
