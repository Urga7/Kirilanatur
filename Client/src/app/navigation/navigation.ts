import {Component, inject, signal} from '@angular/core';
import {RouterLink, RouterOutlet} from '@angular/router';
import {SocialMediaLinks} from '../pages/common/social-media-links/social-media-links';
import {ShoppingBagPreview} from '../pages/common/shopping-bag-preview/shopping-bag-preview';
import {MatBadge} from '@angular/material/badge';
import {ShoppingBag} from '../common/shopping-bag.service';

@Component({
  selector: 'app-navigation',
  imports: [
    RouterOutlet,
    RouterLink,
    SocialMediaLinks,
    ShoppingBagPreview,
    MatBadge
  ],
  templateUrl: './navigation.html',
})
export class Navigation {
  protected readonly navigationExpanded = signal(false);
  protected readonly shoppingBagExpanded = signal(false);
  protected readonly shoppingBag = inject(ShoppingBag)

  toggleNav() {
    const expanded = !this.navigationExpanded();
    this.navigationExpanded.set(expanded);

    // Lock or unlock the body scroll
    document.body.style.overflow = expanded
      ? 'hidden'
      : 'auto';
  }

  toggleShoppingBag() {
    const expanded = !this.shoppingBagExpanded();
    this.shoppingBagExpanded.set(expanded);

    // Lock or unlock the body scroll
    document.body.style.overflow = expanded
      ? 'hidden'
      : 'auto';
  }

  scrollToBottom() {
    this.toggleNav();
    window.scrollTo({top: document.body.scrollHeight});
  }
}
