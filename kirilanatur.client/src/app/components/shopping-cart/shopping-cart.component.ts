import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from "../../services/shopping-cart/shopping-cart.service";
import { Product } from "../../models/database-objects";

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.css'
})
export class ShoppingCartComponent {

  constructor(public shoppingCartService: ShoppingCartService) {}

}
