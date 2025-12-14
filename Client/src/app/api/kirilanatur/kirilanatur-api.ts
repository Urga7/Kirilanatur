import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiClient, HttpRequestMethodType } from '../api-client';
import { GetProductsResponse } from './dtos/get-products-response';
import { GetPricesResponse } from './dtos/get-prices-response';
import { CheckoutRequest, CheckoutResponse } from '../../common/checkout';

@Injectable({
  providedIn: 'root'
})
export class KirilanaturApi {
  private readonly baseUrl = 'http://localhost:5122/api/'
  private readonly httpClient = inject(HttpClient)
  private readonly apiClient = new ApiClient(this.httpClient, this.baseUrl)

  readonly get = {
    products: () => this.apiClient.callApi
      <GetProductsResponse>("products"),

    prices: () => this.apiClient.callApi
      <GetPricesResponse>("prices"),
  }

  readonly post = {
    checkout: (request: CheckoutRequest) => this.apiClient.callApi
      <CheckoutResponse>("checkout", undefined, HttpRequestMethodType.POST, request)
  }
}
