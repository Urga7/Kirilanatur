import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-return',
  standalone: true,
  imports: [CommonModule],
  template: ''
})
export class Return implements OnInit {
  private readonly route = inject(ActivatedRoute)
  private readonly router = inject(Router)
  sessionId: string | null = null

  async ngOnInit() {
    this.sessionId = this.route.snapshot.queryParams['session_id']

    // Optional: Call backend here to verify session status using session_id
    // For simple UI feedback, you can assume 'complete' if redirected here
    // by Stripe, but backend verification is safer.

    if (this.sessionId) {
      void this.router.navigate(['/successful-purchase'])
      // Clear shopping bag here if needed
    } else {
      void this.router.navigate(['/home'])
    }
  }
}
