import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-successful-purchase',
  imports: [],
  templateUrl: './successful-purchase.html'
})
export class SuccessfulPurchase {
  private readonly router = inject(Router)

  protected home() {
    void this.router.navigate(['/home'])
  }
}
