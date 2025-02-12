import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from "../../services/shopping-cart.service";
import { NgOptimizedImage } from '@angular/common';

@Component({
    selector: 'app-shopping-cart',
    templateUrl: './shopping-cart.component.html',
    styleUrl: './shopping-cart.component.css',
    standalone: true,
    imports: [NgOptimizedImage]
})
export class ShoppingCartComponent {

  constructor(public shoppingCartService: ShoppingCartService) {}

}
