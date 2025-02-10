import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  private items: any[] = [];

  constructor() {
    const savedCart = localStorage.getItem('cart');
    if (savedCart)
      this.items = JSON.parse(savedCart);
  }

  getItems() {
    return this.items;
  }

  addItem(item: any) {
    this.items.push(item);
    this.saveCart();
  }

  removeItem(item: any) {
    const index = this.items.indexOf(item);
    if (index > -1) {
      this.items.splice(index, 1);
      this.saveCart();
    }
  }

  clearCart() {
    this.items = [];
    this.saveCart();
  }

  private saveCart() {
    localStorage.setItem('cart', JSON.stringify(this.items));
  }
}
