import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from "@angular/router";

@Component({
  selector: 'app-shop-preview',
  standalone: true,
    imports: [
        RouterLink,
        RouterLinkActive
    ],
  templateUrl: './shop-preview.component.html',
  styleUrl: './shop-preview.component.css'
})
export class ShopPreviewComponent {

}
