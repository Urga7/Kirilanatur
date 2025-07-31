import {computed, Injectable, signal} from '@angular/core';

export interface ShoppingBagItem {
  productId: string
  size: number
  quantity: number
}

@Injectable({
  providedIn: 'root'
})
export class ShoppingBag {
  readonly items = signal<ShoppingBagItem[]>([])
  readonly itemCount = computed(() => {
    return this.items()
      .reduce((currentSum, item) =>
      currentSum + item.quantity, 0)
  })
  readonly totalPrice = computed(() => {
    return this.itemCount() * 78
  })

  addItem(productId: string, size: number, quantity: number = 1) {
    const items = this.items()
    const existingItem = items.find((it) =>
      it.productId === productId &&
      it.size === size
    )

    if (existingItem) {
      existingItem.quantity += quantity
    } else {
      const newItem: ShoppingBagItem = { productId, size, quantity }
      items.push(newItem)
    }

    this.items.set([...items])
  }

  removeItem(productId: string, size: number) {
    const items = this.items()
    const existingItemIndex = items.findIndex((it) =>
      it.productId === productId &&
      it.size === size
    )

    if (existingItemIndex === -1) return

    if (items[existingItemIndex].quantity > 1) {
      items[existingItemIndex].quantity -= 1
    } else {
      items.splice(existingItemIndex, 1)
    }

    this.items.set([...items])
  }
}
