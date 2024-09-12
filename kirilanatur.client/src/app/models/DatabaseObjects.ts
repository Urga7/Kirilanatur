export interface Product {
  id: number
  name: string
  description: string
  price: number
  discount: number
  available: boolean
  images: Image[]
  category: Category
}

export interface Image {
  id: number
  imageUrl: string
  imageDescription: string
}

export interface Category {
  id: number
  name: string
  variations: Variation[]
}

export interface Variation {
  id: number
  name: string
  options: VariationOption[]
}

export interface VariationOption {
  id: number
  value: string
}
