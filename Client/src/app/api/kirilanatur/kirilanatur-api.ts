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
  private readonly baseUrl = 'http://localhost:5122/'
  private readonly httpClient = inject(HttpClient)
  private readonly apiClient = new ApiClient(this.httpClient, this.baseUrl)

  getProducts() {
    return this.apiClient.callApi <GetProductsResponse>("products")
  }

  getPrices(){
    return this.apiClient.callApi <GetPricesResponse>("prices")
  }

  checkout(request: CheckoutRequest) {
    return this.apiClient.callApi <CheckoutResponse>
    ("checkout", undefined, HttpRequestMethodType.POST, request)
  }
}
