export interface GetPricesResponse {
  prices: PriceDto[]
}

export interface PriceDto {
  id: string
  productId: string
  amount: number
  size: number
}
