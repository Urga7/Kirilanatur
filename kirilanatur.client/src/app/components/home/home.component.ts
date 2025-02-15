import { Component } from '@angular/core';
import {ShopPreviewComponent} from "../shop-preview/shop-preview.component";
import {FooterComponent} from "../footer/footer.component";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  imports: [
    ShopPreviewComponent,
    FooterComponent
  ],
  standalone: true
})
export class HomeComponent {

}
