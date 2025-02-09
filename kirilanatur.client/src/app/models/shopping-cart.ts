import { Product, Variation } from "./database-objects";

export interface ShoppingCartItem {
  productId: number
  product: Product
  price: number
  configurations: ChosenVariationOption[]
}

export interface ChosenVariationOption {
  variationId: number
  variationName: string
  variationOptionId: number
  variationOptionLabel: string
}
