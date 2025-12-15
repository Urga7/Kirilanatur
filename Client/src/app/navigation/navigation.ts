import { Component, computed, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SocialMediaLinks } from '../pages/common/social-media-links/social-media-links';
import { ShoppingBagPreview } from '../pages/common/shopping-bag-preview/shopping-bag-preview';
import { MatBadge } from '@angular/material/badge';
import { ShoppingBag } from '../common/shopping-bag.service';
import { NavItem } from './nav-item/nav-item';
import { NavigationUiState } from './navigation-ui-state';

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
  protected readonly shoppingBag = inject(ShoppingBag)
  private readonly uiState = inject(NavigationUiState)
  protected navigationExpanded = computed(() => this.uiState.navigationExpanded())
  protected shoppingBagExpanded = computed(() => this.uiState.shoppingBagExpanded())

  protected readonly navItems: NavigationItem[] = [
    { label: 'DOMOV', route: '/home' },
    { label: 'TRGOVINA', route: '/products' },
    { label: 'ZGODBA', route: '/home', selector: 'story' },
    { label: 'MATERIALI', route: '/home', selector: 'materials' },
    { label: 'KONTAKT', route: '/home', selector: 'contact' },
  ]

  protected toggleNav() {
    this.uiState.toggleNav()
  }

  protected toggleShoppingBag() {
    this.uiState.toggleShoppingBag()
  }
}
