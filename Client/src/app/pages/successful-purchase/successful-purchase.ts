import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShoppingBag } from '../../common/shopping-bag.service';

@Component({
  selector: 'app-successful-purchase',
  imports: [],
  templateUrl: './successful-purchase.html'
})
export class SuccessfulPurchase implements OnInit {
  private readonly router = inject(Router)
  private readonly shoppingBag = inject(ShoppingBag)

  ngOnInit() {
    this.shoppingBag.clear()
  }

  protected home() {
    void this.router.navigate(['/home'])
  }
}
