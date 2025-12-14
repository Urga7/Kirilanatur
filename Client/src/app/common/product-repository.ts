import { computed, inject, Injectable, signal } from '@angular/core';
import { KirilanaturApi } from '../api/kirilanatur/kirilanatur-api';
import { ProductDto } from '../api/kirilanatur/dtos/get-products-response';
import { PriceDto } from '../api/kirilanatur/dtos/get-prices-response';

export interface ProductWithPrices {
  id: string
  name: string
  defaultPrice: number
  mainImage: string
  images: string[]
  exampleUsageImage: string
  prices: ProductPrice[]
}

export interface ProductPrice {
  id: string
  amount: number
  size: number
}

@Injectable({
  providedIn: 'root'
})
export class ProductRepository {
  private readonly api = inject(KirilanaturApi)
  private readonly _products = signal<ProductDto[] | undefined>(undefined)
  private readonly _prices = signal<PriceDto[] | undefined>(undefined)
  readonly productsWithPrices = computed(async () => {
    let products = this._products()
    let prices = this._prices()
    if (products !== undefined && prices !== undefined) {
      return this.dtosToProductsWithPrices(products, prices)
    }

    if (products === undefined && prices === undefined) {
      const [getProductsResponse, getPricesResponse] = await Promise.all([this.api.getProducts(), this.api.getPrices()])
      products = getProductsResponse.data.products
      prices = getPricesResponse.data.prices
    } else if (products === undefined) {
      const getProductsResponse = await this.api.getProducts()
      products = getProductsResponse.data.products
    } else {
      const getPricesResponse = await this.api.getPrices()
      prices = getPricesResponse.data.prices
    }

    this._products.set(products)
    this._prices.set(prices)
    return this.dtosToProductsWithPrices(products, prices!)
  })

  async getProductWithPricesByName(name: string) {
    const products = await this.productsWithPrices();
    return products.find(p => p.name === name);
  }

  private dtosToProductsWithPrices(productDtos: ProductDto[], pricesDtos: PriceDto[]): ProductWithPrices[] {
    const products: ProductWithPrices[] = []
    for (const productDto of productDtos) {
      const prices = pricesDtos
        .filter(p => p.productId === productDto.id)
        .sort((a, b) => a.size - b.size)

      const defaultPrice = prices.find(p => p.id === productDto.defaultPriceId)
      const product: ProductWithPrices = {
        id: productDto.id,
        name: productDto.name,
        defaultPrice: defaultPrice?.amount ?? 0,
        mainImage: productDto.mainImage,
        images: productDto.images,
        exampleUsageImage: productDto.exampleUsageImage,
        prices: prices.map<ProductPrice>(p => ({id: p.id, amount: p.amount, size: p.size}))
      }

      products.push(product)
    }

    return products
  }
}

