import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NavigationUiState {
  private readonly _navigationExpanded = signal(false)
  private readonly _shoppingBagExpanded = signal(false)
  navigationExpanded = this._navigationExpanded.asReadonly()
  shoppingBagExpanded = this._shoppingBagExpanded.asReadonly()

  public toggleNav() {
    const expanded = !this._navigationExpanded()
    this._navigationExpanded.set(expanded)
    this.adjustBodyScrollLock(expanded)
  }

  public toggleShoppingBag() {
    const expanded = !this._shoppingBagExpanded()
    this._shoppingBagExpanded.set(expanded)
    this.adjustBodyScrollLock(expanded)
  }

  public hideOverlay() {
    this._navigationExpanded.set(false)
    this._shoppingBagExpanded.set(false)
    this.adjustBodyScrollLock(false)
  }

  private adjustBodyScrollLock(isOverlayActive: boolean) {
    document.body.style.overflow = isOverlayActive
      ? 'hidden'
      : 'auto'
  }
}
