import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ShoppingBag } from './shopping-bag.service';

@Component({
  selector: 'app-return',
  standalone: true,
  imports: [CommonModule],
  template: ''
})
export class Return implements OnInit {
  private readonly route = inject(ActivatedRoute)
  private readonly router = inject(Router)
  private readonly shoppingBag = inject(ShoppingBag)
  sessionId: string | null = null

  async ngOnInit() {
    this.sessionId = this.route.snapshot.queryParams['session_id']

    if (this.sessionId) {
      this.shoppingBag.clear()
      void this.router.navigate(['/successful-purchase'])
    } else {
      void this.router.navigate(['/home'])
    }
  }
}
