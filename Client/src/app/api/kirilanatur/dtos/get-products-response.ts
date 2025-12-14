export interface GetProductsResponse {
  products: ProductDto[]
}

export interface ProductDto {
  id: string
  name: string
  defaultPriceId: string
  mainImage: string
  images: string[]
  exampleUsageImage: string
}
