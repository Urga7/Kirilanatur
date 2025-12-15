export interface CheckoutRequest {
  items: CheckoutItem[]
}

export interface CheckoutItem {
  priceId: string
  quantity: number
}
