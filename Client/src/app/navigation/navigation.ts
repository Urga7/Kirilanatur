import {Component, signal} from '@angular/core';
import {RouterLink, RouterOutlet} from '@angular/router';
import {SocialMediaLinks} from '../pages/common/social-media-links/social-media-links';

@Component({
  selector: 'app-navigation',
  imports: [
    RouterOutlet,
    RouterLink,
    SocialMediaLinks
  ],
  templateUrl: './navigation.html',
})
export class Navigation {
  protected readonly navigationExpanded = signal(false);

  toggleNav() {
    const expanded = !this.navigationExpanded();
    this.navigationExpanded.set(expanded);

    // Lock or unlock body scroll
    document.body.style.overflow = this.navigationExpanded()
      ? 'hidden'
      : 'auto';
  }

  scrollToBottom() {
    this.toggleNav();
    window.scrollTo({top: document.body.scrollHeight});
  }
}
