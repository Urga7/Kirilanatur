import {computed, Injectable, signal} from '@angular/core';
import { ShoeSize } from '../pages/common/product/product';
import { ProductWithPrices } from './product-repository';

export interface ShoppingBagItem {
  name: string
  image: string
  imageAlt: string
  priceId: string
  price: number
  size: number
  quantity: number
}

@Injectable({
  providedIn: 'root'
})
export class ShoppingBag {
  readonly items = signal<ShoppingBagItem[]>([])
  readonly itemCount = computed(() =>
    this.items()
      .reduce((currentSum, item) =>
      currentSum + item.quantity, 0)
  )
  readonly totalPrice = computed(() => {
    const items = this.items()
    return items.reduce((currentSum, item) =>
      currentSum + item.quantity * item.price, 0)
  })

  addItem(product: ProductWithPrices, shoeSize: ShoeSize, quantity: number = 1) {
    const items = this.items()
    const existingItem = items.find((it) =>
      it.priceId === shoeSize.priceId)

    if (existingItem) {
      existingItem.quantity += quantity
    } else {
      const newItem: ShoppingBagItem = {
        name: product.name,
        priceId: shoeSize.priceId,
        price: product.defaultPrice,
        size: shoeSize.size,
        image: product.mainImage,
        imageAlt: product.mainImage,
        quantity
      }
      items.push(newItem)
    }

    this.items.set([...items])
  }

  removeItem(priceId: string) {
    const items = this.items()
    const existingItemIndex = items.findIndex((it) =>
      it.priceId === priceId)

    if (existingItemIndex === -1) {
      return
    }

    if (items[existingItemIndex].quantity > 1) {
      items[existingItemIndex].quantity -= 1
    } else {
      items.splice(existingItemIndex, 1)
    }

    this.items.set([...items])
  }
}
