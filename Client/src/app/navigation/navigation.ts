import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SocialMediaLinks } from '../pages/common/social-media-links/social-media-links';
import { ShoppingBagPreview } from '../pages/common/shopping-bag-preview/shopping-bag-preview';
import { MatBadge } from '@angular/material/badge';
import { ShoppingBag } from '../common/shopping-bag.service';
import { NavItem } from './nav-item/nav-item';

export interface NavigationItem {
  label: string
  route: string
  selector?: string
}

@Component({
  selector: 'app-navigation',
  imports: [
    RouterOutlet,
    SocialMediaLinks,
    ShoppingBagPreview,
    MatBadge,
    NavItem
  ],
  templateUrl: './navigation.html',
})
export class Navigation {
  protected readonly navigationExpanded = signal(false)
  protected readonly shoppingBagExpanded = signal(false)
  protected readonly shoppingBag = inject(ShoppingBag)

  protected readonly navItems: NavigationItem[] = [
    { label: 'DOMOV', route: '/home' },
    { label: 'TRGOVINA', route: '/products' },
    { label: 'ZGODBA', route: '/home', selector: 'story' },
    { label: 'MATERIALI', route: '/home', selector: 'materials' },
    { label: 'KONTAKT', route: '/home', selector: 'contact' },
  ]

  public toggleNav() {
    const expanded = !this.navigationExpanded()
    this.navigationExpanded.set(expanded)
    this.adjustBodyScrollLock(expanded)
  }

  protected toggleShoppingBag() {
    const expanded = !this.shoppingBagExpanded()
    this.shoppingBagExpanded.set(expanded)
    this.adjustBodyScrollLock(expanded)
  }

  private adjustBodyScrollLock(isOverlayActive: boolean) {
    // Lock or unlock the body scroll
    document.body.style.overflow = isOverlayActive
      ? 'hidden'
      : 'auto'
  }
}
