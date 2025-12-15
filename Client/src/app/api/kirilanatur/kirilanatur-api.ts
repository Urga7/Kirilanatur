import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiClient, HttpRequestMethodType } from '../api-client';
import { GetProductsResponse } from './dtos/get-products-response';
import { GetPricesResponse } from './dtos/get-prices-response';
import { CheckoutRequest } from './dtos/checkout-request';
import { CheckoutResponse } from './dtos/checkout-response';
import { environment } from '../../environments/environment.dev';

@Injectable({
  providedIn: 'root'
})
export class KirilanaturApi {
  private readonly apiUrl = environment.apiUrl
  private readonly httpClient = inject(HttpClient)
  private readonly apiClient = new ApiClient(this.httpClient, this.apiUrl)

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
