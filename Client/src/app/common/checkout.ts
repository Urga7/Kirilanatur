import { Component, inject, OnInit, OnDestroy } from '@angular/core';
import { loadStripe, Stripe, StripeEmbeddedCheckout } from '@stripe/stripe-js';
import { KirilanaturApi } from '../api/kirilanatur/kirilanatur-api';
import { ShoppingBag } from './shopping-bag.service';
import { NavigationUiState } from '../navigation/navigation-ui-state';
import { environment } from '../environments/environment.dev';

@Component({
  selector: 'app-checkout',
  standalone: true,
  template: `<div id="checkout"></div>`
})
export class Checkout implements OnInit, OnDestroy {
  private readonly kirilanaturApi = inject(KirilanaturApi)
  private readonly shoppingBag = inject(ShoppingBag)
  private readonly navigationUiState = inject(NavigationUiState)

  stripe: Stripe | null = null
  checkout: StripeEmbeddedCheckout | undefined

  async ngOnInit() {
    this.navigationUiState.hideOverlay()
    const shoppingBagItems = this.shoppingBag.items()
    const orderItems = shoppingBagItems.map(it => ({
      priceId: it.priceId,
      quantity: it.quantity
    }))

    const response = await this.kirilanaturApi.checkout({ items: orderItems })
    const clientSecret = response.data.clientSecret

    this.stripe = await loadStripe(environment.stripePublicKey)
    if (!this.stripe) {
      console.log('Stripe not loaded')
      return
    }

    this.checkout = await this.stripe.initEmbeddedCheckout({clientSecret})
    this.checkout.mount('#checkout')
  }

  ngOnDestroy() {
    if (this.checkout) {
      this.checkout.destroy()
    }
  }
}
