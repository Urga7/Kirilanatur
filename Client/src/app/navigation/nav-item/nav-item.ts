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
    await this.router.navigate([page])
    if (!selector) return
    void this.scrollWithRetries(selector)
  }

  protected async scrollWithRetries(selector: string, retryCount: number = 10): Promise<void> {
    const el = document.querySelector(selector)
    if (el === null) {
      if (retryCount === 0) return
      await new Promise(resolve => setTimeout(resolve, 100))
      return this.scrollWithRetries(selector, retryCount - 1)
    }

    el.scrollIntoView({ behavior: 'smooth' })
  }
}
