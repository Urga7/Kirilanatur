import {Component, signal} from '@angular/core';
import {RouterLink, RouterOutlet} from '@angular/router';
import {SocialMediaLinks} from '../pages/common/social-media-links/social-media-links';
import {ShoppingBagPreview} from '../pages/common/shopping-bag-preview/shopping-bag-preview';

@Component({
  selector: 'app-navigation',
  imports: [
    RouterOutlet,
    RouterLink,
    SocialMediaLinks,
    ShoppingBagPreview
  ],
  templateUrl: './navigation.html',
})
export class Navigation {
  protected readonly navigationExpanded = signal(false);
  protected readonly shoppingBagExpanded = signal(false);

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
