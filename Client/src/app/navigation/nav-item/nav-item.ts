import { Component, inject, input, output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-item',
  imports: [],
  templateUrl: './nav-item.html'
})
export class NavItem {
  private readonly router = inject(Router)
  readonly label = input.required<string>()
  readonly route = input.required<string>()
  readonly selector = input<string | undefined>(undefined)
  readonly toggleNav = output()

  protected async navigateTo(page: string, selector?: string) {
    this.toggleNav.emit()
    const fragment = selector
    await this.router.navigate([page], { fragment })
  }
}
