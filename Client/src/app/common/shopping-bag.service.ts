import {Injectable, signal} from '@angular/core';

export interface ShoppingBagItem {
  productId: string
  size: number
  quantity: number
}

@Injectable({
  providedIn: 'root'
})
export class ShoppingBag {
  private readonly items = signal<ShoppingBagItem[]>([])

  getItemCount() {
    return this.items().length
  }

  getItems() {
    return this.items()
  }

  addItem(item: ShoppingBagItem) {
    this.items.set([...this.items(), item])
  }

  removeItem(item: ShoppingBagItem) {
    this.items.set(this.items().filter(i => i !== item))
  }
}
